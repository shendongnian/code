    public ActionResult MyPage(MyUrls parameter = MyUrls.Url1)
    {       
    
       if( Enum.IsDefined(typeof(MyUrls), parameter ) )
       {
          //redirect your not found url
       }
         
        return View("MyView");
    }
