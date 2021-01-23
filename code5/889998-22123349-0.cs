    public static void AttachScript(GameObject obj, string scriptClassName)
    {
        if (obj != null)
            obj.AddComponent(scriptClassName);
    }
    public static void AttachScript(string gameObjectName, string scriptClassName)
    {
        var obj = GameObject.Find(gameObjectName);
        if (obj != null)
            obj.AddComponent(scriptClassName);
    }
