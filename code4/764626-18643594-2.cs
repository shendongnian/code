    //Mehod to valid image extensions
    private bool validExtensions(string url)
    {
       var imgs = new []{".jpg",".gif",".png",".bmp",".jpeg"};
       var ext = System.IO.Path.GetFileExtention(url); // see the correct method
                                                           in intellisense
        if(imgs.Contains(ext)
          return false;
    }
