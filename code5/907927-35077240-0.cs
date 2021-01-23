                    WebsitesScreenshot.WebsitesScreenshot _Obj;
                    _Obj = new WebsitesScreenshot.WebsitesScreenshot();
                    WebsitesScreenshot.WebsitesScreenshot.Result _Result;
                    _Result = _Obj.CaptureWebpage("http://www.codeproject.com/");
                    if (_Result == WebsitesScreenshot.
                        WebsitesScreenshot.Result.Captured)
                    {
                        _Obj.PreserveAspectRatio = true;
                        _Obj.ImageWidth = 200;
                        _Obj.ImageHeight = 300;
                        _Obj.JpegQuality = 80;//here you set numbers from 1 to 100
                        _Obj.ImageFormat = WebsitesScreenshot.
                WebsitesScreenshot.ImageFormats.JPG;
                        _Obj.SaveImage("D:\\WebpageThumbnailer.jpg");
                        //_Obj.
                    }
                    _Obj.Dispose();
