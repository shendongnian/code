    public class MyUserControl : UserControl
    {
        private MyExtraControlCode _Extras;
        public MyUserControl()
        {
            _Extras = new MyExtraControlCode(this);
        }
        public int GetInt32Value()
        {
            return _Extras.GetInt32Value();
        }
    }
    public class MyTextBox : TextBox
    {
        private MyExtraControlCode _Extras;
        public MyTextBox()
        {
            _Extras = new MyExtraControlCode(this);
        }
        public int GetInt32Value()
        {
            return _Extras.GetInt32Value();
        }
    }
