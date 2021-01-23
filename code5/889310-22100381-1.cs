    public static void GetLocation()
    {
    DataClasses_DataContext dc = new DataClasses_DataContext();
    var locations = (
        from a
            in dc.Locations
        select new { Name = a.Name, Id = a.Id }).ToList(); // this can be Id = a.Name or whatever too
    DropDownList ddLocation = new DropDownList();
    ddLocation.DataSource = locations;
    ddLocation.DataValueField = "ID";
    ddLocation.DataTextField = "Name";
    ddLocation.SelectedIndex = 0;
    ddLocation.DataBind();
    }
