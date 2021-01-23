    internal class CustomODataPathHandler : DefaultODataPathHandler
    {
        #region Methods
        protected override ODataPathSegment ParseAtEntityCollection(IEdmModel model, ODataPathSegment previous, IEdmType previousEdmType, string segment)
        {
            ODataPathSegment customActionPathSegment;
            if (TryParseCustomAction(model, previous, previousEdmType, segment, out customActionPathSegment))
            {
                return customActionPathSegment;
            }
            return base.ParseAtEntityCollection(model, previous, previousEdmType, segment);
        }
        protected override ODataPathSegment ParseAtEntity(IEdmModel model, ODataPathSegment previous, IEdmType previousEdmType, string segment)
        {
            ODataPathSegment customActionPathSegment;
            if (TryParseCustomAction(model, previous, previousEdmType, segment, out customActionPathSegment))
            {
                return customActionPathSegment;
            }
            return base.ParseAtEntity(model, previous, previousEdmType, segment);
        }
        protected override ODataPathSegment ParseEntrySegment(IEdmModel model, string segment)
        {
            var container = model.EntityContainers().First();
            if (CouldBeCustomAction(container, segment))
            {
                ODataPathSegment customActionPathSegment;
                if (TryParseCustomAction(model, segment, out customActionPathSegment))
                {
                    return customActionPathSegment;
                }
            }
            return base.ParseEntrySegment(model, segment);
        }
        private bool TryParseCustomAction(IEdmModel model, ODataPathSegment previous, IEdmType previousEdmType, string segment, out ODataPathSegment pathSegment)
        {
            var container = model.EntityContainers().First();
            if (segment.StartsWith(container.Name + "."))
            {
                var actionName = segment.Split('.').Last();
                var action = (from f in container.FindFunctionImports(actionName)
                              let parameters = f.Parameters
                              where parameters.Count() >= 1 && parameters.First().Type.Definition.IsEquivalentTo(previousEdmType)
                              select f).FirstOrDefault();
                if (action != null)
                {
                    pathSegment = new ActionPathSegment(action);
                    return true;
                }
            }
            pathSegment = null;
            return false;
        }
        private bool TryParseCustomAction(IEdmModel model, string segment, out ODataPathSegment pathSegment)
        {
            var container = model.EntityContainers().First();
            if (CouldBeCustomAction(container, segment))
            {
                var actionName = segment.Split('.').Last();
                var action = (from f in container.FindFunctionImports(actionName)
                              where f.EntitySet == null && !f.IsBindable
                              select f).FirstOrDefault();
                if (action != null)
                {
                    pathSegment = new ActionPathSegment(action);
                    return true;
                }
            }
            pathSegment = null;
            return false;
        }
        private static bool CouldBeCustomAction(IEdmEntityContainer container, string segment)
        {
            return segment.StartsWith(container.Name + ".");
        }
        #endregion
    }
