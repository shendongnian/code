    private static void PlaceOrder()
        {            
            
      
           
            string data = "your string"; 
             
            WebClient webClient = new WebClient();            
            webClient.Headers["Content-type"] = "application/json";            
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString("http://localhost:61090/OrderService.svc
                            /PlaceOrder", "POST", data);              
        }
