    using (var ctx = new ClientContext(webUri))
    {
         var list = ctx.Web.Lists.GetByTitle("Tasks");
         var field = list.Fields.GetByInternalNameOrTitle("Predecessors");
         var lookupField = ctx.CastTo<FieldLookup>(field);
         ctx.Load(lookupField);
         ctx.ExecuteQuery();
         var lookupListId = new Guid(lookupField.LookupList);
         //Retrieve associated List
         var lookupList = ctx.Web.Lists.GetById(lookupListId);
         ctx.Load(lookupList);
         ctx.ExecuteQuery();
    }
