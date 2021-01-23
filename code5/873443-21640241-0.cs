    private int _counter = 0
    
    protected void AddFileInputControl_Click(object sender, EventArgs e)
    {
        fileinputs_div.Controls.Add(new FileUpload()
        {
            ID = string.Format("image #{0}", _counter);
        });
        _counter++;
    }
