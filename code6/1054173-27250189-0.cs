    public static async Task<object> AwaitResult(Task t)
    {
        await t;
        return t.GetType().GetProperty("Result").GetValue(t, null);
    } 
