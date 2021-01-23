    string errorMessage = string.Empty;
    try 
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage response = await    
      client.GetAsync("http://localhost:12345/api/items");
    
      var info = new List<SampleDataGroup>();
    
      if (response.IsSuccessStatusCode)
      {
        var content = await response.Content.ReadAsStringAsync();
    
        var item = JsonConvert.DeserializeObject<dynamic>(content);
    
        foreach (var data in item)
        {
            var infoSect = new SampleDataGroup
            (
                (string)data.Id.ToString(),
                (string)data.Name,
                (string)"",
                (string)data.PhotoUrl,
                (string)data.Description
            );
            info.Add(infoSect);
        }
      }
      else
      {
          errorMessage = "Error";
      }      
    }    
    catch (Exception ex)
    {
      ErrorMessage = ex.Message;
    }
    if (errorMessage != string.Empty) 
    {
      MessageDialog dlg = new MessageDialog(errorMessage);
      await dlg.ShowAsync();
    }
 ?
