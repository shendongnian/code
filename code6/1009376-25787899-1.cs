    private async void button_Click(object sender, EventArgs e)
    {
      await Task.Run(() => getContactInformation());
    }
    public void getContactInformation()
    {
      this.data.Add(collectData1());
      this.data.Add(collectData2());
      this.data.Add(collectData3());
      this.data.Add(collectData4());
      this.data.Add(collectData5());
    }
