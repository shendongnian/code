    void Main()
    {
    	var test = Newtonsoft.Json.JsonConvert.DeserializeObject<Test>(getTestObjects().Result).Dump();
    
    	// test.Name; 'Bad Boys'
    	// test.ReleaseDate; '1995-4-7T00:00:00'
    }
    
    public class Test
     {   
         public String Name { get; set; }
         public String ReleaseDate { get; set; }
     }
    
     private string url = "http://bitg.ir/files/json.txt";
     private List<Test> TestList = new List<Test>();
    
     private async Task<String> getTestObjects()
     {
         var httpClient = new HttpClient();
         var response = await httpClient.GetAsync(url);
    	 var result = await response.Content.ReadAsStringAsync();
    	 
    	 return result;
     }
