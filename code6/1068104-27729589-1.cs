    protected internal void FormCaller(object sender, EventArgs e)
    {
       DataGridView Sender = (DataGridView)sender;
       string FormName = Sender.CurrentCell.Value.ToString(); //This is how i identify the cell who raise the event
       NForm = new myForm(this);
       NForm.Text = FormName;
    }
