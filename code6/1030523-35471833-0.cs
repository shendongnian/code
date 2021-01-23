    var pageManager = PageManager.GetManager();
                pageManager.Provider.SuppressSecurityChecks = true;
               
                var rootPages = pageManager.GetPageNodes()
                                           .AsEnumerable()
                                           .Where(p => !p.IsBackend && p.Parent != null && p.Parent.Title.ToLower() == "pages" && p.ShowInNavigation && p.ApprovalWorkflowState == "Published")                    
                                           .OrderBy(p => p.Ordinal)
                                           .ToList();
