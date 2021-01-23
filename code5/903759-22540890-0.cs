    MyObject myObject;
    if (response.IsSuccessStatusCode)
    {
    	// Parse the response body. Blocking!
    	myObject = response.Content.ReadAsAsync<MyObject>().Result;
    }
