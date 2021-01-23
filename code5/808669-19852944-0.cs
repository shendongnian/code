    gridLookUpEdit.Properties.DisplayMember = "Name";
    gridLookUpEditView.Columns.Add(
        new GridColumn() { FieldName = "Name", Visible = true });
    gridLookUpEditView.Columns.Add(
        new GridColumn() { FieldName = "Country.Name", Caption = "Country", Visible = true });
    gridLookUpEdit.Properties.DataSource = new List<City> { 
        new City() { Name="New York", Country = new Country() { Name = "USA" } },
        new City() { Name="London", Country = new Country() { Name = "UK" } },
    };
