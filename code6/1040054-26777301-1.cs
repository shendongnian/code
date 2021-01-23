     Html.Kendo()
        .PanelBar()
        .Name("catalogBar")
        .ExpandMode(PanelBarExpandMode.Single)
                .Items(items =>
                {
                    // here is the trick to add the items dynamically
                    foreach (YourApplication.Models.Catalog detail in ViewBag.Catalogs)
                    {
                        items.Add()
                            .Text(detail.Name)
                            .LoadContentFrom(Url.Action("CourseDetails", "YourController", new { id = detail.Id }));
                    }
    
                })
    )
