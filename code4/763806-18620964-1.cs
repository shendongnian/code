    public class FormOptions : Form
    {
        ...
        private MyOptions _options;
        public MyOptions Options 
        {
            get { return _options;}
            set
            {
                _options = value;
                // Set the Form's control values accordingly.
            }
        }
        ...
    }
