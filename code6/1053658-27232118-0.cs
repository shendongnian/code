    // form 1 click
    var form2 = new Form2() { SomeData = TextBoxForm1.Text; }
    this.Visible = false;
    form2.ShowDialog(this);
    this.Visible = true;
    TextBoxForm1.Text = form2.SomeData;
    
    // form 2 shown
    TextBoxForm2.Text = SomeData;
    // form 2 click
    SomeData = TextBoxForm2.Text;
    Close();
