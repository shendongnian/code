    public static bool IsTextboxVisible (IWebDriver driver, Dictionary of all needed data )
    {    
     //Verify text-box is visible
      var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
     
      var Textbox = wait.Until(d => d.FindElement(By.ClassName("ig_content")));
      SwitchIFrame(driver,stringXPath);
      return Textbox.Displayed;
    }
    
    public static void SwitchIFrame (IWebDriver driver,string strXPath)
    {
        //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
        var iFrame = driver.FindElement(By.XPath(strXPath));
        driver.SwitchTo().Frame(iFrame);
    }
