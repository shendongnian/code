     public class SimpleDropdown
    {
        //
        // Summary:
        //     Gets or sets the text of the selected item.
        //
        // Returns:
        //     The text.
        public string Text { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the selected item.
        //
        // Returns:
        //     The value.
        public string Value { get; set; }
    }
    public class SingleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SimpleDropdown> dddl { get; set; }
        public int SelectedEmp { get; set; }
    }
    public class MainModel
    {
        public List<SingleEntity> main_model_list { get; set; }
    }
    
