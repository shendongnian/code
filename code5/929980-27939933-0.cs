     public ActionResult StaticPage()
            {
                var name = new Uri(Request.Url.ToString()).Segments.Last();
                return new FilePathResult(name, "text/html");
            }
