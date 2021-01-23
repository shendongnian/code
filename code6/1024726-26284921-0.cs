    public class Form1
    {
        private Form2 _form2;
        public void ShowForm2()
        {
            if(_form2 == null)
            {
                _form2 = new Form2();
                _form2.Bind(this);
            }
            this.Hide();
            _form2.Show();
        }
    }
    public class Form2
    {
        private Form1 _form1;
    
        public Bind(Form1 form1)
        {
            _form1 = form1;
        }
        public void ShowForm1()
        {
            this.Hide();
            _form1.Show();
        }
    }
