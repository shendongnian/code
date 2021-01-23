    public async Task updateAllResults()
    {
        var tasks = PairList.Select(async (item) => 
        {
            var data = await Parse.JsonParse<PairResults>
                .getJsonString("http://localhost:22354/" + item.Original)
                .ConfigureAwait(false);
            item.part1 = data.value;
        });
        await Task.WhenAll(tasks.ToArray());
    }
    // button click handler
    async void button_Click(object s, EventArgs e)
    {
        this.button.Enabled = false;
        try
        {
            await updateAllResults()
        }
        finally
        {
            this.button.Enabled = true;
        }
    }
