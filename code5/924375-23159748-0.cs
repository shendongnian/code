    public static class NetworkLayer{
        public static WebClient wc;
    
        public void InitializeWebClient(){
           wc = new WebClient();       
        }
        public void MakeCall(Uri uri){
          if(!wc.isBusy){
              wc.DownloadStringCompleted += (s,a)=>
              {  
                 //Get your results
              };
    
              wc.DownloadStringAsync(uri);
           }
        }
    }
