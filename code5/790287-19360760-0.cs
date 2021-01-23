    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Test2(Test2Model model)
            {
                var rnd = new Random();
                var random = rnd.Next(10000).ToString();
                var response = string.Format("<input id=\"MyID\" name=\"MyID\" type=\"hidden\" value=\"{0}\">", random);
                return Content(response);
            }
		
