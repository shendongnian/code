    protected override void OnDoubleClick(EventArgs e)
    {
        base.OnDoubleClick(e);
            
        // The rest of you code here
        // The rest of you code here
        // The rest of you code here
              
        button1.Click += delegate
        {
            res_name = textBox1.Text;
            res_value = Convert.ToInt32(textBox2.Text);
            MessageBox.Show(res_name + res_value.ToString());
        };
        textBox1.KeyPress += delegate(object sender, KeyPressEventArgs ev)
        {
            ev.Handled = !char.IsLetter(ev.KeyChar) && !char.IsControl(ev.KeyChar) && !char.IsSeparator(ev.KeyChar);
        };
        textBox2.KeyPress += delegate(object sender, KeyPressEventArgs ev)
        {
            if (char.IsLetter(e.KeyChar) && char.IsControl(e.KeyChar))
                e.Handled = true;
        };
        form.ShowDialog(); // <----------- MODAL call, all the code is added BEFORE it
    }
