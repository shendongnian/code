    public static async Task<JObject> GetJsonAsync(Uri uri)
    {
      using (var client = new HttpClient())
      {
        var jsonString = await client.GetStringAsync(uri);
        return JObject.Parse(jsonString);
      }
    }
    
    // My "top-level" method.
    public void Button1_Click(...)
    {
      var jsonTask = GetJsonAsync(...);
      textBox1.Text = jsonTask.Result;
    }
