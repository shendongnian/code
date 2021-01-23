            string Sk = "List&lt;ImageInfoModel&gt; imgList = new List&lt;ImageInfoModel&gt;();<br/>";
            Sk += "string imgPath = @";
            Sk += "\"~/Content/Images/ImageGallery/\";<br/>";
            Sk += "string tmbPath = @";
            Sk += "\"~/Content/Images/ImageGallery/thumbnails/\";<br/>";
            Sk += "string imgFullPath = Server.MapPath(imgPath);<br/>string tmbFullPath = Server.MapPath(tmbPath);";
            ViewBag.Sk = Sk;
