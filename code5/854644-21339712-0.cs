    public class dataObj
    {
       public string type { get; set; }
       public string subject { get; set; }
       public int priority { get; set; }
       public string status { get; set; }
       public IList<string> labels { get; set; }
       public IDictionary<string, string> message { get; set; }
    }
    private void testbutton_Click(object sender, EventArgs e)
        {
            try {
                string json = @"{
                    ""type"": ""email"",
                    ""subject"": ""Creating a case via the API"",
                    ""priority"": 4,
                    ""status"": ""open"",
                    ""labels"": [
                    ""Spam"",
                    ""Ignore""
                    ],
                ""message"": {
                ""direction"": ""in"",
                ""status"": ""received"",
                ""to"": ""someone@desk.com"",
                ""from"": ""someone-else@desk.com""
                }
              }";
                dataObj data = Newtonsoft.Json.JsonConvert.DeserializeObject<dataObj>(json);
        
            }
            catch { 
            
            }
        }
