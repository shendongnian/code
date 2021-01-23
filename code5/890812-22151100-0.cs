    private void Form1_Load(object sender, EventArgs e)
            {
                Fiddler.FiddlerApplication.AfterSessionComplete += Fiddler_AfterSessionComplete;
                Fiddler.FiddlerApplication.Startup(0, Fiddler.FiddlerCoreStartupFlags.Default);
    
             }
    
        private void Fiddler_AfterSessionComplete(Fiddler.Session osession)
            {
                listWatch.Invoke(new UpdateUI(() =>
                {
    
                   if(osession.fullUrl == "Your Url")
                    {
                     //bind data
                    }
                  
               }));
    
    
            }
