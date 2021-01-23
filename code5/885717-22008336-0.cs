    // Define our new view
            var templateIconView = new TemplateIconView { ID = TemplateIconViewControlId };
            var pageManager = PageManager.GetManager();
            pageManager.Provider.SuppressSecurityChecks = true;
            // Get the root
            var parentNode = pageManager.GetPageNode(SiteInitializer.SitefinityNodeId);
            // Check whether exists
            var initialPageNode = pageManager.GetPageNodes().SingleOrDefault(n => n.Id == AdditionalToolsPageId);
            if (initialPageNode != null) {
                pageManager.Delete(initialPageNode);
                pageManager.SaveChanges();
            }
            var homePageNode = pageManager.GetPageNodes().SingleOrDefault(n => n.Id == HomePageId);
            if (homePageNode != null) {
                pageManager.Delete(homePageNode);
                pageManager.SaveChanges();
            }
            // Create the Group Page Node
            var groupPageNode = pageManager.CreatePage(parentNode, AdditionalToolsPageId, NodeType.Group);
            groupPageNode.Name = "KonstruiTools";
            groupPageNode.Description.SetString("Konstrui Tools", true);
            groupPageNode.Title.SetString("Konstrui Tools", true);
            groupPageNode.UrlName = Regex.Replace("Konstrui Tools", @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-").ToLower();
            groupPageNode.ShowInNavigation = true;
            groupPageNode.DateCreated = DateTime.UtcNow;
            groupPageNode.LastModified = DateTime.UtcNow;
            pageManager.SaveChanges();
            // Create the actual page PageData
            var pageData = pageManager.CreatePageData(HomePageId);
            pageData.HtmlTitle = "Configure Template Icons";
            pageData.Title = "Configure Template Icons";
            pageData.Description = "Configure Template Icons";
            pageData.Culture = Thread.CurrentThread.CurrentCulture.ToString();
            pageData.UiCulture = Thread.CurrentThread.CurrentUICulture.ToString();
            pageData.EnableViewState = true;
            pageData.EnableViewStateMac = true;
            // Add our control to the page with default permissions
            var control = pageManager.CreateControl<PageControl>(templateIconView, Constants.VALUE_DEFAULT_BACKEND_PLACEHOLDER);
            pageManager.SetControlDefaultPermissions(control);
            pageData.Controls.Add(control);
            // Assign the Default Backend Template
            pageData.Template = pageManager.GetTemplate(SiteInitializer.DefaultBackendTemplateId);
            // Create the actual page PageNode
            var pageNode = pageManager.CreatePage(groupPageNode, HomePageId, NodeType.Standard);
            pageNode.Page = pageData;
            pageNode.Name = "ConfigureTemplateIcons";
            pageNode.Description = "Configure Template Icons";
            pageNode.Title = "Configure Template Icons";
            pageNode.UrlName = Regex.Replace("Configure Template Icons", @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-").ToLower();
            pageNode.ShowInNavigation = true;
            pageNode.DateCreated = DateTime.UtcNow;
            pageNode.LastModified = DateTime.UtcNow;
            pageNode.RenderAsLink = true;
            pageManager.SaveChanges();
            // Publish
            var bag = new Dictionary<string, string>();
            bag.Add("ContentType", typeof(PageNode).FullName);
            WorkflowManager.MessageWorkflow(HomePageId, typeof(PageNode), null, "Publish", false, bag);
            pageManager.Provider.SuppressSecurityChecks = false;
