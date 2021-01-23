    public class Global : HttpApplication
        {
            public static List<Images> col = new List<Images>();
            private void GetImages()
            {
                // Build this collection as per your requirement. This is just a sample. 
                // Logic is to store current, next, previous image details for current displaying image/page. 
                // Hope while storing image each will have unique name before saving and will have all details in db like path, display name, etc.
                col.Add(new Images("orderedList0.png", "orderedList0", "orderedList1", ""));
                col.Add(new Images("orderedList1.png", "orderedList1", "orderedList2", "orderedList0"));
                col.Add(new Images("orderedList2.png", "orderedList2", "orderedList3", "orderedList1"));
                col.Add(new Images("orderedList3.png", "orderedList3", "orderedList4", "orderedList2"));
                col.Add(new Images("orderedList4.png", "orderedList4", "", "orderedList3"));
            }
    
            void Application_Start(object sender, EventArgs e)
            {
                GetImages();            
                RegisterRoutes(RouteTable.Routes);
            }
    
            public static void RegisterRoutes(RouteCollection routeCollection)
            {
                routeCollection.MapPageRoute("RouteForImage", "Posts/{Name}", "~/Posts.aspx");
    
            } 
    }
