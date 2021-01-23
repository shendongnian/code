         public string ReturnTable()
    {
            var report=productService.DailyBestSellersReport(param1,param2,param2)
        
              StringBuilder sb=new StringBuilder();
        
               foreach(var r in report)
              {
    
              //I believe u r trying to build Html table so u can append any string here to sb
    
              }
            return sb.ToString();
    
    }
