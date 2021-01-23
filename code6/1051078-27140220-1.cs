     public ActionResult DynamicLinks()
            {
                List<DynamicHyperLink> model = new List<DynamicHyperLink>()
                {
                    new DynamicHyperLink(){
                        Text = "Some Text Here", 
                        Link = "http://www.somelink.com"
                    }, 
                     new DynamicHyperLink(){
                        Text = "Some Other Text ", 
                        Link = "http://www.someotherlink.com"
                    }
                };
    
                return View(model); 
    
            }
