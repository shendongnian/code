    @(Html.Telerik().Grid<MyViewModel>()
      .Name("Grid")
      .Columns(cols =>
        {
          cols.Bound(o => o.Property1);
          cols.Bound(o => o.Property2)
              .EditorTemplateName("Property2Template"); // this your .cshtml filename
        })
      .DataBinding(binding =>
        {
           //etc
        })
      // remainder of grid code
    )
