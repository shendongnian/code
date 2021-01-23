       var products=builder.EntitySet<Vehicle>("Products");
       products.HasNavigationPropertiesLink(
                    product.NavigationProperties,
                    (entityContext, navigationProperty) =>
                    {
                        object id;
                        entityContext.EdmObject.TryGetPropertyValue("ID", out id);
                        return new Uri(entityContext.Url.Link(ODataTestConstants.DefaultRouteName,
                    new
                    {
                        odataPath = entityContext.Url.CreateODataLink(
                            new EntitySetPathSegment(entityContext.NavigationSource.Name),
                            new KeyValuePathSegment(id.ToString()),
                            new NavigationPathSegment(navigationProperty))
                    }));
                    }, true);
