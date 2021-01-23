    public class MyModule : NancyModule
    {
        public MyModule()
        {
            Get["api/entities", ctx => ctx.Query.ContainsKey("page") && ctx.Query.ContainsKey("pageSize")] = p => DoStuff();
            Get["api/entities", ctx => !(ctx.Query.ContainsKey("page") && ctx.Query.ContainsKey("pageSize"))] = p => DoOtherStuff();
        }
    }
