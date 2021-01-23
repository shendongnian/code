    public class DropDownListModel
    {
        public DropDownListModel()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add( new SelectListItem() { Text = "one", Value = "one" } );
            items.Add( new SelectListItem() { Text = "two", Value = "two" } );
            VehicleList = new SelectList( items, "Value", "Text" );
        }
        public string Vehicle { get; set; }
        public SelectList VehicleList { get; set; }
    }
