                    var pageId = Guid.NewGuid();
           
                    PageManager manager = PageManager.GetManager();
              
                    PageNode pageNode = null;
                    //Find the modules section which will serve as the 
                    //parent page.
                    string pageTitle = ConfigurationManager.AppSettings["ModulesSection"].ToString();
                  
                    //Gets the actual Modules page.
                    var modulesNode = SitefinityHelper.GetPageNode(pageTitle);
                    if (modulesNode.Id == Guid.Empty)
                    {
                        modulesNode.Id = SiteInitializer.CurrentFrontendRootNodeId;
                    }
                    PageNode modulesPage = manager.GetPageNode(modulesNode.Id);
                    // Check whether exists
                    var initialPageNode = manager.GetPageNodes().Where(n => n.Id ==     
                    pageId).SingleOrDefault();
                    if (initialPageNode != null)
                    {
                        return false;
                    }
                    
                    //Creates the page under the Modules section as a Group Page.
                    pageNode = manager.CreatePage(modulesPage, pageId, NodeType.Group);
                    pageNode.Name = newModule.Name;
                    pageNode.Description = newModule.Description;
                    pageNode.Title = newModule.Name;
                    pageNode.UrlName = Regex.Replace(newModule.Name.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                    pageNode.ShowInNavigation = true;
                    pageNode.DateCreated = DateTime.UtcNow;
                    pageNode.LastModified = DateTime.UtcNow;
                    manager.SaveChanges();e here
