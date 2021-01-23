       public void Start()
        {
            List<IWebElement> elements = _seleniumAdapter.AllElementsOnPage();
            Debug.WriteLine("Elementcount: " + elements.Count);
            int i = _random.Next(elements.Count);
            IWebElement element = elements[i];
        
            Debug.WriteLine(element.TagName + "," + element.Text);
            try
            {
            element.Click();
            }
            catch(StaleElementReferenceException ex)
            {
               elements = _seleniumAdapter.AllElementsOnPage();
               element = elements[i];
               element.Click()
                 
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                element = null;
            }
            if(element != null)
           {
            if (element.GetAttribute("type").Contains("text"))
            {
                Debug.WriteLine("text!");
                element.SendKeys(randomLetter());
            }
            Start();
           }
        
        }
