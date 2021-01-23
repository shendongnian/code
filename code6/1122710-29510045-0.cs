    //Form1.cs
    public string val; 'create public value
    Form1_Load()
    {
        val = textbox.txt; 'load textbox value to val
    }
    //Form2.cs
    Form2_Load()
    {
        lbl.Text = Form1.val;
    }
