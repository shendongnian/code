    // This would likely be a partial view with per-user output caching
    @Html.BuildNavigation(new List<NavigationItem>
    {
        new NavigationItem("Production", MVC.Production.Home.Index()),
        new NavigationItem("Inventory", MVC.Inventory.Home.Index()),
        new NavigationItem("Quality Control", MVC.QualityControl.Home.Index()),
        new NavigationItem("Customers", MVC.Sales.Home.Index()),
        new NavigationItem("Vendors", MVC.Vendors.Companies.Index()),
    })
