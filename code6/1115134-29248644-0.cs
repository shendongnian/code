            string Sk = "List<imageinfomodel> imgList = new List<imageinfomodel>();<br/>";
            Sk += "string imgPath = @";
            Sk += "\"~/Content/Images/ImageGallery/\"<br/>";
            Sk += "string tmbPath = @";
            Sk += "\"~/Content/Images/ImageGallery/thumbnails/\"<br/>";
            Sk += "string imgFullPath = Server.MapPath(imgPath);<br/>string tmbFullPath = Server.MapPath(tmbPath);";
            ViewBag.Sk = Sk;
