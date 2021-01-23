    private Form1 _form1;
    ...
    public Form2(Form1 form1)
    {
        _form1 = form1;
    }
    ...
    private void changeForm1_Click(object sender, EventArgs e)
    {
        StaticVariables.labelString = textBox.Text; 
        _form1.ChangeLabel();
    }
