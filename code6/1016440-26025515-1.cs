    public class MyMode{
    public int Parameter1{get;set;}
    public int Parameter2{get;set;}
    }
    
    [HttpPost]
    public async Task<IHttpActionResult> MyActionMethod(HttpRequestMessage request, MyModel model){
        var parameter1 = model.Parameter1;
        var parameter2 = model.Parameter2;
    }
