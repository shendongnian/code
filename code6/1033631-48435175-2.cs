UtilityTools.cs
    <!-- language: lang-cs -->
    
        using System;
        using System.Reflection;
        using System.ComponentModel.DataAnnotations;
        namespace UtilityTools
        {
            public static class T4Helpers
            {
                public static bool IsRequired(string viewDataTypeName, string propertyName)
                {
                    bool isRequired = false;
        
                    Type typeModel = Type.GetType(viewDataTypeName);
                    if (typeModel != null)
                    {
                        PropertyInfo pi = typeModel.GetProperty(propertyName);
                        Attribute attr = pi.GetCustomAttribute<RequiredAttribute>();
                        isRequired = attr != null;
                    }
        
                    return isRequired;
                }
            }
        }
