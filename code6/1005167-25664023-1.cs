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
            bFalse = false;
        }
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            bFalse = true;
            base.OnSelectionChangeCommitted(e);
        }
    }
