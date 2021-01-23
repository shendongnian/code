    private async void button2_Click(object sender, EventArgs e)
    {
      var customerIDs = File.ReadAllLines(@"c:\temp\customerids.txt").ToList();
      var updates = customerIDs.Select(id => DoSomethingWithTheCustomerAsync(id));
      var results = await Task.WhenAll(updates);
      MessageBox.Show("Done");
    }
