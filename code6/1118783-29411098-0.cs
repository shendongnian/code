            IList<IWebElement> row = date.FindElements(By.TagName("tr"));
            IList<IWebElement> col = date.FindElements(By.TagName("td"));
           
            foreach (IWebElement cell in col)
            {
                if (cell.Text.Equals("13"))  
                {
                    cell.Click();
                    break;
                }    
            }
