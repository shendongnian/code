    public class ComboBoxCustomType<TCustomType> : System.Windows.Forms.ComboBox
    {
        //Hide base.Items property by our wrapping class
        public new ComboBoxList<TCustomType> Items; 
        public ComboBoxCustomType() : base()
        {
            this.Items = new ComboBoxList<TCustomType>(base.Items);
        }
        public new TCustomType SelectedItem 
        { 
            get { return (TCustomType)base.SelectedItem; } 
        }
    }
