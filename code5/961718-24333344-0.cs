    public static class MyGenericClass<T> where T : class
    {
        public static T MyGenericMethod()
        {
        T o = (T)Activator.CreateInstance(typeof(T));
        PropertyInfo[] pi = typeof(T).GetProperties();
        for(int i = 0; i < pi.Count(); i++) 
        {
            if(pi[i].Name == "MyClass2Property") 
            {
                //How to proceed ?
                Type t = typeof (MyGenericClass<>);
                Type genericType = t.MakeGenericType(new System.Type[] { pi[i].PropertyType });
                var c = Activator.CreateInstance(genericType);
                var mgm = Convert.ChangeType(c, genericType);
                mgm.MyGenericMethod(); 
            }
            else 
            {
                pi[i].SetValue(o, Convert.ChangeType(someValue, pi[i].PropertyType), null);
            }
        }
    }
    
    
