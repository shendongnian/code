    var cars = (EdmEntitySet)edmModel.EntityContainers().Single().FindEntitySet("Cars");
    var parts = (EdmEntitySet)edmModel.EntityContainers().Single().FindEntitySet("Parts");
    var carType = (EdmEntityType)edmModel.FindDeclaredType("MyNamespace.Car");
    var partType = (EdmEntityType)edmModel.FindDeclaredType("MyNamespace.Part");
    var partsProperty = new EdmNavigationPropertyInfo();
    partsProperty.TargetMultiplicity = EdmMultiplicity.Many;
    partsProperty.Target = partType;
    partsProperty.ContainsTarget = false;
    partsProperty.OnDelete = EdmOnDeleteAction.None;
    partsProperty.Name = "Parts";
    var navigationProperty = carType.AddUnidirectionalNavigation(partsProperty);
    cars.AddNavigationTarget(navigationProperty, parts);
    
    var linkBuilder = edmModel.GetEntitySetLinkBuilder(cars);
    linkBuilder.AddNavigationPropertyLinkBuilder(navigationProperty, 
        new NavigationLinkBuilder((context, property) =>
            context.GenerateNavigationPropertyLink(property, false), true));
