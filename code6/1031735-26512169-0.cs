    private void MyGrid_FieldLayoutInitialized(object sender, Infragistics.Windows.DataPresenter.Events.FieldLayoutInitializedEventArgs e) 
    {
        Field fld = e.FieldLayout.Fields.Where(f => f.Name == "PropertyToNotDisplay").FirstOrDefault();
        if (fld != null) fld.Visibility = System.Windows.Visibility.Collapsed;
        fld = e.FieldLayout.Fields.Where(f => f.Name == "AnotherPropertyToNotDisplay").FirstOrDefault();
        if (fld != null) fld.Visibility = System.Windows.Visibility.Collapsed;
    }
