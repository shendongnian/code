        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values.ContainsKey("q"))
            {
                if (Page.RouteData.Values["q"] !=null)
                {
                    string p = (string)Page.RouteData.Values["q"];
                    switch (p)
                    {
                        case "a":
                            //do something
                        case "b":
                        //do something
                        case "c":
                            // Do Something
                            break;
                        case "d":
                            // Do Something
                            break;
                        default:
                            // Do Something
                            break;
                    }
                }
            }
        }
