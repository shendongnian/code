    class ViewModel
    {
        Form1 frm = new Form1();
        Data data = new Data();
        public ViewModel(Form1 _frm)
        {
            frm = _frm;
            foreach (Control ctrl in frm.Controls)
                if (ctrl is DoubleTextBox)
                {
                    (ctrl as DoubleTextBox).AllowNull = true;
                    (ctrl as DoubleTextBox).DataBindings.Add("BindableValue", data, "Age");
                }
            frm.Show();
        }
    }
        public class Data
        {
            private double? _age = null;
            public double? Age
            {
                get { return _age; }
                set { _age = value; }
            }
        }
