            [HttpPost]
            public ActionResult PostMethod()
            {
                System.Threading.Thread.Sleep(1000);
                return Content(""); 
            }
