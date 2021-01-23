    @model namespace.ViewModels.ColumsViewModel
    
    @using (Html.BeginForm("SelectedColumns", "Home", FormMethod.Post))
    {
         @Html.ListBoxFor(m => m.SelectedNames, Model.Names, new Dictionary<string, object> { { "size", "15" } })
    }
