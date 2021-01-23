    class Form
    {
        Button _button1, _button2;
    
        public Form()
        {
            _button1 = new Button("button1");
            _button2 = new Button("button2");
    
            _button1.Click += _button_Click;
            _button2.Click += _button_Click;
        }
    
        void _button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name);
        }
    
        public void Click1()
        {
            _button1.FireEvent();
        }
    
        public void Click2()
        {
            _button2.FireEvent();
        }
    }
    
    class Button
    {
        public event EventHandler Click;
        public string Name;
    
        public Button(string name)
        {
            Name = name;
        }
    
        public void FireEvent()
        {
            Click(this, new EventArgs());
        }
    }
