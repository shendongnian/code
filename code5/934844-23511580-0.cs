    public partial class DynamicContent : UserControl
    {
        public DynamicContent(){InitializeComponent();}
        
        public void AddComboBox(ComboBox combobox)
        {
            LayoutRoot.Childre.Add(combobox);
        }
    }
