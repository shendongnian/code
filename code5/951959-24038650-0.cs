    //Initialize the LRS
    var lrs = new RemoteLRS("https://cloud.scorm.com/tc/public/", "<username>", "<password>");  
    //Initialize the TinCan Actor for Launch String
    this.Actor = new TinCan.Agent();
    this.Actor.name = this.User.Forename + " " + this.User.Surname;
    this.Actor.mbox = this.User.Email;
    //Construct the TinCanStartPage
    TINCANStartPage = HttpContext.Current.Request.Url.Scheme + "://" + @HttpContext.Current.Request.Url.Host + ":" +
                    @HttpContext.Current.Request.Url.Port + HttpContext.Current.Request.ApplicationPath + this.Course.BlobURL + this.LaunchPage;
