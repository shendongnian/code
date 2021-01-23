    public async void Button1_Click(...)
    {
      var json = await GetJsonAsync(...);
      textBox1.Text = json;
    }
    
    public class MyController : ApiController
    {
      public async Task<string> Get()
      {
        var json = await GetJsonAsync(...);
        return json.ToString();
      }
    }
