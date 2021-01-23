    using System;
    using System.Linq;
    using System.Reflection;
    using Helpers.Aspects;
    using PostSharp.Aspects;
    using PostSharp.Extensibility;
    
    [assembly: EmptyStringModelBindingAspect(
        AttributeTargetTypes = @"regex:[^\.]*\.Controllers\..*Controller",
        AttributeTargetTypeAttributes = MulticastAttributes.Public,
        AttributeTargetElements = MulticastTargets.Method,
        AttributeTargetMemberAttributes = MulticastAttributes.Public)]
    
    namespace Helpers.Aspects
    {
        [Serializable]
        public class EmptyStringModelBindingAspect : MethodInterceptionAspect
        {
            public override void OnInvoke(MethodInterceptionArgs args)
            {
                for (int i = 0; i < args.Arguments.Count; i++)
                {
                    FixString(args, i);
                    FixStringsInObjects(args.Arguments[i]);
                }
    
                args.Proceed();
            }
    
            private static void FixString(MethodInterceptionArgs args, int i)
            {
                if (args.Arguments[i] is string && args.Arguments[i] == null)
                {
                    args.Arguments.SetArgument(i, string.Empty);
                }
            }
    
            private static void FixStringsInObjects(object obj)
            {
                if (obj == null)
                {
                    return;
                }
    
                var type = obj.GetType();
                var properties = (from p in type.GetProperties() 
                                             let paramerers = p.GetIndexParameters() 
                                             where !paramerers.Any() 
                                             where p.PropertyType == typeof (string) && 
                                                   p.CanRead && 
                                                   p.CanWrite && 
                                                   p.GetValue(obj, null) == null 
                                             select p).ToArray();
    
                foreach (var item in properties)
                {
                    item.SetValue(obj, string.Empty, null);
                }
            }
    
            public override bool CompileTimeValidate(MethodBase method)
            {
                return !(method.Name.StartsWith("get_") || method.Name.StartsWith("set_"));
            }
        }
    }
