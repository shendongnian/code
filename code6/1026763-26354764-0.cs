    if (Request.Content != null) {
        if (System.Web.HttpContext.Current.Request.ContentType.StartsWith(MediaType.Xml)) {
            //Perform your Logic here
        }
        /*
        //you can skip below  MediaType.Json  block 
        if (System.Web.HttpContext.Current.Request.ContentType.StartsWith(MediaType.Json)) {
        }
        */
    }
