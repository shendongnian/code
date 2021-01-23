     public static void DoSomething<TModel>(Expression<Func<TModel, List<string>>> selectNamesFunc, TModel model)
     {
         var f = selectNamesFunc.Compile();
         var names = f.Invoke(model);
     }
