     [DllImport("C:\\ManagerApp.dll", CharSet = CharSet.Unicode, 
          EntryPoint = "?initFunc@ManagerAPI@@QAEHXZ")]
        private static extern int initFunc();
        public ActionResult APITest()
        {
            ViewBag.Message = "API output test page.";
            if (initFunc() == 0)
            {
                ViewBag.Error = "Could not initialize the library.";
                return View();
            }
            ManagerAPIWrapper.ManagerAPIWrapper wrapper = new ManagerAPIWrapper.ManagerAPIWrapper();
            ViewBag.DllMessage = wrapper.testFunc();
            return View();
        }
