        public void TestMethod()
        {
              if (Context.User.IsInRole("Admin"))
               {
                 uc1:adminlinks.Visible = true;
                }
              else
             {
               uc1:adminlinks.Visible = false;
             }
        }
