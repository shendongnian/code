            var page = Page.Form.FindControl("MainContent").FindControl("myNewDiv").Controls;
            for (var i = 0; i < 10; i++)
            {
                var ele = new HtmlGenericControl("div")
                {
                    InnerHtml = string.Format("new div {0}", i), 
                    ID = string.Format("NewDiv_{0}", i)
                };
                page.Add(ele);
            }
