            string userName="";
            string userId = "";
            int uid = 0;
            if (HttpContext.Current != null && HttpContext.Current.User != null
                      && HttpContext.Current.User.Identity.Name != null)
            {
                userName = HttpContext.Current.User.Identity.Name;              
            }
            using (DevEntities context = new DevEntities())
            {
                  uid = context.Users.Where(x => x.UserName == userName).Select(x=>x.Id).FirstOrDefault();
                return uid;
            }
               
            return uid;
