    private async void btnDoWebRequest_Click(object sender, EventArgs e)
    {
      btnDoWebRequest.Enabled = false;
      await DoWebRequestsAsync();
      btnDoWebRequest.Enabled = true;
    }
