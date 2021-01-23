    private int _counter = 0
    
    protected void AddFileInputControl_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < _counter; i++)
        {
            fileinputs_div.Controls.Add(new FileUpload()
            {
                ID = string.Format("image #{0}", i);
            });    
        }
        
        _counter++;
    }
