    using System.Net.Http;
    //Windows.Web.Http 
    
    string URI = "http://www.myurl.com/post.php";
    string myParameters = "param1=value1&param2=value2&param3=value3"; 
           
    sendData(URI,myParameters);
    
    
    public async void sendData(string URI,string myParameters)
     {
     	using(HttpClient hc = new HttpClient())
    	{
    		Var response = await hc.PostAsync(URI,new StringContent (myParameters));
    	}
    }
