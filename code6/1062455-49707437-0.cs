               checksomeelement:
            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(driver.FindElements(By.XPath("//div[@class='video']/a")));
            if (elementList.Count > 0)
            {
                elementList[0].Click();
            }
            else
            {
                System.Threading.Thread.Sleep(2000);
                goto checksomeelement;
            }
