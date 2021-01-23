    public void SomeMethod(Type t)
        {
            if (t.GetInterfaces().Contains(typeof(IMyInterface)) && 
                   t.GetConstructor(Type.EmptyTypes)!=null)
            {
                var obj=(IMyInterface)Activator.CreateInstance(t);
                myList.Add(obj);
            }
        }
