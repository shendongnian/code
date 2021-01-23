    private void callSerializeObj(object obj)
        {
            Type objType = obj.GetType();
            
           MethodInfo method = this.GetType().GetMethod("SerialiazeObj", BindingFlags.NonPublic | BindingFlags.Instance);
           MethodInfo generic = method.MakeGenericMethod(objType );
           object Result = generic.Invoke(this, new object[] { obj });
        }
