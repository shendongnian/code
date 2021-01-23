                using(NewsDetailViewController nDVC=new NewsDetailViewController(news,_newsEnum))
                {
                    this.NavigationController.NavigationBar.BarTintColor = ExtensionMethods.ToUIColor("4BC1D2");
                    this.NavigationController.NavigationBar.TintColor=UIColor.White;
                    this.NavigationController.PushViewController (nDVC, true);  
                }
