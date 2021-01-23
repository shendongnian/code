            string clientContext = "http://yourteamsiteslocation";
            List<string> tableNames = new List<string>();
            //Get a context
            using (SharePointclientObj.ClientContext ctx = new SharePointclientObj.ClientContext(clientContext))
            {
                //Get the site
                SharePointclientObj.Web site = ctx.Web;
                ctx.Load(site);
                //Get Lists
                ctx.Load(site.Lists);
                //Query
                ctx.ExecuteQuery();
                //Fill List                
                foreach (SharePointclientObj.List list in site.Lists)
                {
                    //Console.WriteLine(list.Title);
                    tableNames.Add(list.Title);
                    //listBox1.Items.Add(list.Title);
                }
            }
