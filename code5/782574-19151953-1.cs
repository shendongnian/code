    public void ClientCacheLoadRerquest(Type tType, string key)
        {
            MethodInfo method = this.GetType().GetMethod("GetCache");
            MethodInfo closedMethod = method.MakeGenericMethod(tType);
            closedMethod.Invoke(this, new object[] { key });
        }
