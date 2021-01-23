      public int DeleteFromWishlist(long pid)
        {
            int result = 0;
            List<Int64> ls_p = new List<Int64>();
            HttpCookie mycookie = null;
            ls_p = Deserialize<List<Int64>>(Convert.ToString(HttpContext.Current.Request.Cookies["wishlist"].Value));
            var prd = ls_p;
            {
                {
                    ls_p.Remove(ls_p.FirstOrDefault(p=>p==pid));
                    string data = SerializeItem<List<Int64>>(prd);
                    mycookie = HttpContext.Current.Request.Cookies["wishlist"];
                    mycookie.Value = data;
                    mycookie.Expires = DateTime.Now.AddMonths(1);
                    HttpContext.Current.Response.Cookies.Add(mycookie);
                    result = 1;
                }
            }
            return result;
        }
