    .ObserveOn(SchedulerService.TaskPool)
    .Select(x =>
    {
       var api = factory.Create();
       using (new Duration())
       {
          var intellisenseDictionary = ExtractIntellisense(api.GetFieldExpressionAssemblies().Single());
          //return intellisenseDictionary;
          return new Dictionary<string, string[]>();
     }
