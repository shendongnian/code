    private System.Threading.Timer my5AmTimer = null;
    protected override void OnStart(string[] args)
    {
        //All other code..
    
       this.my5AmTimer = new System.Threading.Timer(callback, null, next5am - DateTime.Now, TimeSpan.FromHours(24));
    }
