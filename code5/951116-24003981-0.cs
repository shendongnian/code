        textBox1.TextChanged += textBox1_TextChanged;
        MessageBox.Show("asdf");
        textBox1.TextChanged -= textBox1_TextChanged;        
        textBox1.Text = DateTime.Now.ToString();
        textBox1.TextChanged += textBox1_TextChanged;
        var eventField = textBox1.GetType().GetField("TextChanged", BindingFlags.GetField
                                                                   | BindingFlags.NonPublic
                                                                   | BindingFlags.Instance);
    
        var subscriberCount = ((EventHandler)eventField.GetValue(textBox1))
                    .GetInvocationList().Length;
