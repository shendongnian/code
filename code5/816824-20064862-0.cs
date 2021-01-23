    class MyButton: Button
    {
        // put here attributes to stop its serialization into code and displaying in the designer
        public new string Text
        {
            get {return base.Text;}
            set {base.Text = value;}
        }
        public MyButton() : base()
        {
            base.Text = Resources.ButtonText;
        }
    }
