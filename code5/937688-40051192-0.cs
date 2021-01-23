        public List<string> GetValidations()
        {
            IList<IWebElement> elementList = _webDriver.FindElements(By.Id("validationList")); // note the FindElements, plural.
            List<string> validations = new List<string>();
            foreach (IWebElement element in elementList)
            {
                validations.Add(element.ToString());
            }
            return validations;
        }
