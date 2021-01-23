    using System.Reflection;
    
    public class PersonController
    {
        public void Create(int x, string propName)
        {
            var p = new Person();
            obj.GetType().InvokeMember(propName,
               BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
               Type.DefaultBinder, obj, x);
        }
    }
