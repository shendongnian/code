            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
            [TestMethod]
            public void openBrw()
            {
    
                BrowserWindow browser = BrowserWindow.Launch("www.google.com");
                UITestControl UISearch = new UITestControl(browser);
                UISearch.TechnologyName = "Web";
                UISearch.SearchProperties.Add("ControlType", "Edit");
                UISearch.SearchProperties.Add("Id", "lst-ib");
    //search by column1
                Keyboard.SendKeys(UISearch, TestContext.DataRow["column1"].ToString());            
    
            }
