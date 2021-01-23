    foreach (var navProp in products.EntityType.NavigationProperties)
                {
     products.HasNavigationPropertyLink(
               navprop,
               (entityContext, navigationProperty) =>
               {
                   object id;
                   entityContext.EdmObject.TryGetPropertyValue("ID", out id);
                   return new Uri(entityContext.Url.CreateODataLink(
                         new EntitySetPathSegment(navprop.Name),
                         new KeyValuePathSegment(id.ToString())
                         ));
               }, false);
    }
