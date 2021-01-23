    public partial class MyCombo : ComboBox
    {
        public MyCombo()
        {
            InitializeComponent();
        }
        bool bFalse = false;
        protected override void OnTextChanged(EventArgs e)
        {
            //Here you can handle the TextChange event if want to suppress it 
            //just place the base.OnTextChanged(e); line inside the condition
            if (!bFalse)
                base.OnTextChanged(e);
        }
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            bFalse = true;
            base.OnSelectionChangeCommitted(e);
        }
        protected override void OnTextUpdate(EventArgs e)
        {
            base.OnTextUpdate(e);
            bFalse = false; //this event will be fire when user types anything. but, not when user selects item from the list.
        }
    }
