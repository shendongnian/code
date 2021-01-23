          if (Request.Cookies["Test"] == null)
            {
                HttpCookie testCookie = new HttpCookie("Test");
                testCookie.Value = "1";
                testCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(testCookie);
            }
            else
            {
                var c = Request.Cookies["Test"];
                c.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(c);
                HttpCookie testCookie = new HttpCookie("Test");
                testCookie.Value = "2";
                testCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(testCookie);
            }
