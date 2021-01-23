    /// <summary>
    /// Bind SP Data Source 
    /// </summary>
    private void BindSPDataSource()
    {
        var data = GetListItems("Tasks");
        var result = XElement.Parse(data.OuterXml);
        XNamespace z = "#RowsetSchema";
        var taskItems = from r in result.Descendants(z + "row") select new
                {
                    TaskName = r.Attribute("ows_LinkTitle").Value,
                    DueDate = r.Attribute("ows_DueDate") != null ? r.Attribute("ows_DueDate").Value : string.Empty,
                    AssignedTo = r.Attribute("ows_AssignedTo") != null ? r.Attribute("ows_AssignedTo").Value : string.Empty,
                };
        dgTasks.ItemsSource = taskItems; 
    }
