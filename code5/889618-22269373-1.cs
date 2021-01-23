      InitializeComponent();
      List<ComboboxData> cmb = new List<ComboboxData>();
      cmb.Add(new ComboboxData("1.","Tidle", "~"));
      cmb.Add(new ComboboxData("2.", "Exclamation", "!"));
      cmb.Add(new ComboboxData("3.", "Ampersat", "@"));           
      cmb.Add(new ComboboxData("4.","Ampersand", "&"));
      cmb.Add(new ComboboxData("5.","Dollar", "$"));
      Combobox.ItemsSource = cmb;
      Combobox1.ItemsSource = cmb;
     public class ComboboxData
    {
        public string index { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public ComboboxData(string index,string name,string symbol)
        {
            this.index = index;
            this.name = name;
            this.symbol = symbol;
        }
    }
