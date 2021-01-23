     var listTitle = "Documents";
     var query = new CamlQuery();
     query.ViewXml = "<View Scope='RecursiveAll' />";
                   
     var items = ctx.Web.Lists.GetByTitle(listTitle).GetItems(query);
     ctx.Load(items,icol => icol.Include(
                    i => i.ContentType,
                    i => i.FieldValues));
     ctx.ExecuteQuery();
