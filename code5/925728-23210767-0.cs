    boolean found = false;
    while (!found) {
    try
    {
       var dropName = new SelectElement(driver.FindElement(By.Id("drop_Name")));
       dropName.SelectByText(stringText);
       found = true;  
    }
    catch (NoSuchElementException)
    {
       var dropName = new SelectElement(driver.FindElement(By.Id("drop_Name")));
       dropName.SelectByText(stringText); 
       //do a short sleep here e.g. 500ms depending on the speed of your site  
    }
    
    }
