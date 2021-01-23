    class MyBaseClass
    {   }
    class MyBaseClass_impl : MyBaseClass
    {   }
    public MyBaseClass CreateFromMetaData(string metaData)
    {
        string className = "MyNamespace.MyBaseClass_" + metaData;
        Type t = System.Reflection.Assembly.GetExecutingAssembly().GetType(className, false);
        if (t != null)
        {
            return (MyBaseClass)Activator.CreateInstance(t);
        }
        return null;
    }
