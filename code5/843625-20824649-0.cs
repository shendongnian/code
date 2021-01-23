    public MainWindowViewModel()
    {
        using (Lab_Lite_Entities db = new Lab_Lite_Entities())
        {
            // A single select from the database
            var design = db.Designs.FirstOrDefault(
                d => d.MasterPage.Value == "Haemogram Report" && 
                     d.FieldName == "Test");
            // Build your members from that select
            HaemogramRowTest    = design != null ? design.ParentGridRow : null;
            HaemogramColumnTest = design != null ? design.ParentGridColumn : null;
            ...       
 
