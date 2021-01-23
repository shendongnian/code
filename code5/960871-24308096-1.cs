    FileStream file = new FileStream(string.Format(@"Z:\Stream\order{0}.csv",       txtName.Text),FileMode.OpenOrCreate);
    StreamWriter wr = new StreamWriter(file);
    wr.WriteLine(txtName.Text);
    wr.WriteLine(txtOrderRef.Text);
    List<TextBox> textboxControls = new List<TextBox>();
    foreach (var control in Panel1.Controls)
    {
       if(control is TextBox)
       {
          Textbox tb = control as TextBox;
          wr.WriteLine(tb.Text);
          textboxControls.Add(tb); //not needed in this context, but may be used in code elsewhere
       }
    }
