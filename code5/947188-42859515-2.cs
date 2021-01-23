    public FileResult GetCaptchaImage(DateTime dt)
    {
        CaptchaRandomImage CI = new CaptchaRandomImage();
        this.Session["CaptchaImageText"] = CI.GetRandomString(5); // here 5 means I want to get 5 char long captcha
        //CI.GenerateImage(this.Session["CaptchaImageText"].ToString(), 300, 75);
        // Or We can use another one for get custom color Captcha Image 
        CI.GenerateImage(this.Session["CaptchaImageText"].ToString(), 300, 75, Color.DarkGray, Color.White);
        MemoryStream stream = new MemoryStream();
        CI.Image.Save(stream, ImageFormat.Png);
        stream.Seek(0, SeekOrigin.Begin);
        return new FileStreamResult(stream, "image/png");
    }
    //One more action as
    [HttpPost]
    public ActionResult _GetCaptcha()
    {
        return PartialView();
    }
