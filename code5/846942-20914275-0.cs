        Form2 obj2 = new Form2();
        private void button1_Click(object sender, EventArgs e)
        {
            if (obj2 != null && obj2.Visible) { obj2.Focus(); return; }
    
            obj2 = new Form2();
            obj2.ShowDialog(this);
        }
