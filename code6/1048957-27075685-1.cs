    public async Task ReadCodes()
    {
        foreach (var line in lines)
        {
            string text = await Task.Run(() =>
            {
                //foo code
                // return text;
            });
            this.lblUsedFiles.Text = text;
        }
        //some other foo
    }
