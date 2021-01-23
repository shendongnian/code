    private async void button1_Click(object sender, EventArgs e)
    {
        this.button1.Enabled = false;
        
        var result = await GetMyTableAsync();
        
        MessageBox.Show(result.Count);
        
        this.button1.Enabled = true;
    }
    
    private async Task<IList<MyTableEntity>> GetMyTableAsync()
    {
        using( var context = new MyEFContext() )
        {
            return await context.MyTable.ToListAsync()
                 .ConfigureAwaiter(false);
        }
    }
