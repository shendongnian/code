    private void Form1_Load(object sender, EventArgs e)
        {
        var c = GetAll(this,typeof(TextBox));
        foreach (TextBox item in c)
            item.TextChanged += new EventHandler(textBox1_TextChanged);
        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //set textbox tag = true to check whether text changed or not
            ((TextBox)sender).Tag=true;
        }
    
        public IEnumerable<Control> GetAll(Control control,Type type)
        {
            var controls = control.Controls.Cast<Control>();
    
            return controls.SelectMany(ctrl => GetAll(ctrl,type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    
        // now you can get changed checkbox 
        List<TextBox> getchangedtextbox(){
        var c = GetAll(this,typeof(TextBox));
            // not get list of changed checkbox witch have null value in TAG
           return c.Select(a=>a.Tag!=null);
        }
