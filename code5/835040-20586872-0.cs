    if (Request.Cookies["IPortalCookies"]["Likes"] == null || Request.Cookies["IPortalCookies"]["Likes"].Contains("'" + articleid + "'") == false)
            //        {
            //            if (_ah.LikeIt(articleid))
            //            {
            //                Response.Cookies["IPortalCookies"]["Likes"] = Request.Cookies["IPortalCookies"]["Likes"] + ",'" + articleid + "'";
            //                BindRepeater();
            //            }
            //        }
