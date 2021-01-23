    using Microsoft.VisualStudio.TestTools.UITesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
     
    namespace Blog.Example
    {
        public static class CodedUIExtension
        {
     
            public static T SearchFor<T>(this UITestControl _this, dynamic searchProperties, dynamic filterProperties = null) where T : UITestControl, new()
            {
                T ctrl = new T();
                ctrl.Container = _this;
                IEnumerable<string> propNames = ((object)searchProperties).GetPropertiesForObject();
     
                foreach (var item in propNames)
                {
                    ctrl.SearchProperties.Add(item, ((object)searchProperties).GetPropertyValue(item).ToString());
                }
     
                if (filterProperties != null)
                {
                    propNames = ((object)filterProperties).GetPropertiesForObject();
                    foreach (var item in propNames)
                    {
                        ctrl.FilterProperties.Add(item, ((object)filterProperties).GetPropertyValue(item).ToString());
                    }
                }
                return ctrl as T;
            }
     
            private static IEnumerable<string> GetPropertiesForObject(this object _this)
            {
                return (from x in _this.GetType().GetProperties() select x.Name).ToList();
            }
            private static object GetPropertyValue(this object _this, string propName)
            {
                var prop = (from x in _this.GetType().GetProperties() where x.Name == propName select x).FirstOrDefault();
                return prop.GetValue(_this);
            }
        }
    }
