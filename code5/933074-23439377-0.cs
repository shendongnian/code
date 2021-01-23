    // root event handler
    private async void button_Click(object s, EventArgs e)
    {
        await ReadInputFile();
    }
    private async Task ReadInputFile()
    {
        var reader = new StreamReader(File.OpenRead(FilePath + @"\" + FileNameAdd));
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            var values = line.Split(',');
            var Newline = new RevenueLine();
            Newline.ClubID = values[0];
            Newline.Date = values[1];
            Newline.Department = values[2];
            Newline.Description = values[3];
            Newline.Chits = Convert.ToInt32(values[4]);
            Newline.Sales = values[5];                
            await UpdatePOS_Monitor(Newline);
        }
    }
    private async Task UpdatePOS_Monitor(RevenueLine line)
    {
        using (HttpClient client = new HttpClient())
        {
            string json = JsonConvert.SerializeObject(line);
            HttpResponseMessage wcfResponse = await client.PostAsync(API_Address, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
