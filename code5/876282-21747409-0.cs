    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    namespace DashboardTest
    {
        public struct ResourceInfo
        {
            public ResourceInfo(string resourceKey, DependencyProperty property)
                : this()
            {
                ResourceKey = resourceKey;
                Property = property;
            }
            public string ResourceKey { get; private set; }
            public DependencyProperty Property { get; set; }
        }
        public static class DataTemplateHelper
        {
            private static readonly Type ChildValueLookupType = GetType("System.Windows.ChildValueLookup");
            private static readonly FieldInfo LookupTypeField = ChildValueLookupType.GetField("LookupType", BindingFlags.Instance | BindingFlags.NonPublic);
            private static readonly FieldInfo ValueField = ChildValueLookupType.GetField("Value", BindingFlags.Instance | BindingFlags.NonPublic);
            private static readonly FieldInfo PropertyField = ChildValueLookupType.GetField("Property", BindingFlags.Instance | BindingFlags.NonPublic);
            private static readonly object LookupTypeResource = Enum.Parse(LookupTypeField.FieldType, "Resource");
            public static List<ResourceInfo> FindDynamicResources(DataTemplate template)
            {
                var recordField = typeof(DataTemplate).GetField("ChildRecordFromChildIndex", BindingFlags.Instance | BindingFlags.NonPublic);
                Debug.Assert(recordField != null);
                var values = EnumerateObjects(recordField.GetValue(template)).Where(IsDynamicResource).Select(ToResourceInfo).ToList();
                return values;
            }
            private static ResourceInfo ToResourceInfo(object lookup)
            {
                return new ResourceInfo((string)ValueField.GetValue(lookup), (DependencyProperty)PropertyField.GetValue(lookup));
            }
            private static Type GetType(string typeName)
            {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    Type type = assembly.GetType(typeName);
                    if (type != null)
                        return type;
                }
                return null;
            }
            private static bool IsDynamicResource(object obj)
            {
                if (obj == null || obj.GetType() != ChildValueLookupType) return false;
                return LookupTypeResource.Equals(LookupTypeField.GetValue(obj));
            }
            private static IEnumerable<object> EnumerateObjects(object obj)
            {
                var visited = new HashSet<object>();
                EnumerateObjectsInternal(obj, visited, 20);
                return visited;
            }
            private static void EnumerateObjectsInternal(object obj, HashSet<object> visited, int maxDepth)
            {
                if (obj == null || maxDepth <= 0) return;
                var type = obj.GetType();
                if (obj is Type || obj is string || obj is DateTime || type.IsPrimitive
                    || type.IsEnum || visited.Add(obj) == false) return;
                var array = obj as Array;
                if (array != null)
                {
                    foreach (var item in array)
                    {
                        EnumerateObjectsInternal(item, visited, maxDepth - 1);
                    }
                }
                else
                {
                    foreach (var field in GetAllFields(type))
                    {
                        var fieldValue = field.GetValue(obj);
                        EnumerateObjectsInternal(fieldValue, visited, maxDepth - 1);
                    }
                }
            }
            private static IEnumerable<FieldInfo> GetAllFields(Type type)
            {
                const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;
                if (type == typeof(object) || type.BaseType == typeof(object))
                {
                    return type.GetFields(bindingFlags);
                }
                else
                {
                    var fieldInfoList = new List<FieldInfo>();
                    var currentType = type;
                    while (currentType != typeof(object))
                    {
                        fieldInfoList.AddRange(currentType.GetFields(bindingFlags));
                        currentType = currentType.BaseType;
                    }
                    return fieldInfoList;
                }
            }
        }
    }
