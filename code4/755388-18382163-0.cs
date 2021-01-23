    public void OtherMethod<T>() where T : class {
        if (typeof(IMyInterface).IsAssignableFrom(typeof(T))) {
            MethodInfo method = this.GetType().GetMethod("DoStuff");
            MethodInfo generic = method.MakeGenericMethod(typeof(T));
            generic.Invoke(this, null);
        }
    }
