    protected SelectElement GetSelectElement(By selector)
    {
        bool flag = new WebDriverWait(Driver, TimeSpan.FromSeconds(30)).Until(c =>
        {
            try
            {
                new SelectElement(Driver.FindElement(selector));
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        });
    
        if (flag)
        {
            return new SelectElement(Driver.FindElement(selector));
            
        }
        else
        {
            //something
        }
        
        return null;
    }
