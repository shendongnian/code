    public void SomeMethodInForm1()
    {
       Form2 form2 = new Form2();
       // Show form2 as a modal dialog and determine if DialogResult = OK. 
       if (form2.ShowDialog(this) == DialogResult.OK)
       {
          // Read the contents of form2's TextBox. 
          this._items.Add(form2.textBox1.Text);
          this._items.Add(form2.textBox2.Text);
          this._items.Add(form2.comboBox1.Text);
          this.listBox1.DataSource = null;
          this.listBox1.DataSource = _items;
       }
       form2.Dispose();
    }
