    public static class FieldExtensions
    {
        /// <summary>
        /// Remove column and reference from specific content types
        /// </summary>
        /// <param name="field"></param>
        /// <param name="contentTypeId"></param>
        public static void DeleteObject(this Field field,string contentTypeId)
        {
            var ctx = field.Context as ClientContext;
            if (!field.IsPropertyAvailable("Id"))
            {
                ctx.Load(field, f => f.Id);
                ctx.ExecuteQuery();
            }
            //Firstly, remove site column from content type
            var contentType = ctx.Site.RootWeb.ContentTypes.GetById(contentTypeId);
            var fieldLinks = contentType.FieldLinks;
            var fieldLinkToRemove = fieldLinks.GetById(field.Id);
            fieldLinkToRemove.DeleteObject();
            contentType.Update(true); //push changes
            //Then remove column
            field.DeleteObject();
        }
        /// <summary>
        /// Remove column and references from all content types
        /// </summary>
        /// <param name="field"></param>
        /// <param name="includeContentTypes"></param>
        public static void DeleteObject(this Field field, bool includeContentTypes)
        {
            var ctx = field.Context as ClientContext;
            if (!field.IsPropertyAvailable("Id"))
            {
                ctx.Load(field, f => f.Id);
                ctx.ExecuteQuery();
            }
            //Firstly, remove site column link from all content types
            ctx.Load(ctx.Site.RootWeb.AvailableContentTypes, cts => cts.Include(ct => ct.FieldLinks));
            ctx.ExecuteQuery();
            foreach (var ct in ctx.Site.RootWeb.AvailableContentTypes)
            {
                var containsField = ct.FieldLinks.Any(fl => fl.Id == field.Id);
                if (containsField)
                {
                    var fieldLinkToRemove = ct.FieldLinks.GetById(field.Id);
                    fieldLinkToRemove.DeleteObject();
                    ct.Update(true); //push changes         
                }
            }
            //Then remove site column
            field.DeleteObject();
        }
    }
