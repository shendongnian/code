    class Form1: Form
    {
        private State state = new State();
        public Form1()
        {
            Load += HandleLoad;
        }
    
        public HandleLoad(object sender, EventArgs e)
        { 
            label1.DataBindings.Add("Text", state, "IsChecked"); // or just query state.IsChecked
        }
        public void someEvent_Handler()
        {
            Form2 form2 = new Form2();
            form2.Bind(state);
            form2.Show();
        }
    }
    
    class Form2: Form
    {
        public void Bind(State state)
        {
            checkBox1.DataBindings.Add("Checked", state, "IsChecked");
        }
    }
    
    class State
    {
        public bool IsChecked {get;set;}
    }
