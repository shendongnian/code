    public partial class MyCombo : ComboBox
    {
        public MyCombo()
        {
            InitializeComponent();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            //Here you can handle the TextChange event if want to suppress it 
            //just place the base.OnTextChanged(e); line inside the condition
            If (true)
                base.OnTextChanged(e);
        }
    }
