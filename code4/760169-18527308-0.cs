     public static int Points
            {
                get
                {
                    int points = Convert.ToInt32( HttpContext.Current.Session["PointssessionKey"]); 
                    return  points;
                }
                set
                {
                    HttpContext.Current.Session["PointssessionKey"] = value;
                }
            }
