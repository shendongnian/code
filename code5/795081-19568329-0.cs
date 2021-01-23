    static List<LuaFunction> hooks = new List<LuaFunction>();
    
    // Register this void
    public void HookIt(LuaFunction func)
    {
        hooks.Add(func);
    }
    
    public static void WhenEntityCreates(Entity ent)
    {
        // We want to delete entity If we're returning true as first arg on lua
        // And hide it If second arg is true on lua
        foreach (var run in hooks)
        {
            var obj = run.Call(ent);
            if (obj.Length > 0)
            {
                if ((bool)obj[0] == true) ent.Remove();
                if ((bool)obj[1] == true) ent.Hide();
            }
        }
    }
