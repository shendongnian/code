    foreach (string from1 in from)
    {
    	foreach (string to1 in To)
    	{
    		driver.Navigate().GoToUrl(www.xyz.com);
    		System.Threading.Thread.Sleep(5000);
    		driver.FindElement(By.Id("tbFrom")).Clear();
    		driver.FindElement(By.Id("tbFrom")).SendKeys(from1);
    		driver.FindElement(By.Id("tbTo")).Clear();
    		driver.FindElement(By.Id("tbTo")).SendKeys(to1);
    		
    		var infoElement = driver.FindElement(By.Id("trAirLines"));
    		Assert.That(infoElement.Text, Is.StringContaining("Air Canada"));
    	}
    }
