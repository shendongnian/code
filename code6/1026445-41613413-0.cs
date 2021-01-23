     public static WebDriverWait wait = new WebDriverWait(SeleniumInfo.Driver, TimeSpan.FromSeconds(20));
        public static void WaitUntilAttributeValueEquals(this IWebElement webElement, String attributeName, String attributeValue)
            {            
                    wait.Until<IWebElement>((d) =>
                    {
                        if (webElement.GetAttribute(attributeName) == attributeValue)
                        {
                            return webElement;
                        }
                        return null;
                    });
            }
