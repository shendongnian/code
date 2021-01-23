        class ViewModel
    {
        Form1 frm = new Form1();
        Data data = new Data();
        public ViewModel(Form1 _frm)
        {
            frm = _frm;
            foreach (Control ctrl in frm.Controls)
                if (ctrl is DoubleTextBox)
                    (ctrl as DoubleTextBox).DataBindings.Add("Text", data, "unit");
            Application.Run(frm);
        }
    }
       
    public class Data
    {
        private double n_unit = -5;
        public double unit
        {
            get { return n_unit; }
            set { n_unit = value; }
        }
    }
