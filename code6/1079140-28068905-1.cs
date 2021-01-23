        [Test]
        [TestCaseSource("WillsTestData")]
        public void WillsTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(WillsNavigation.Index);
            var willsDriver = new WillsDriver(driver);
            this.WillsCustomerDetail(willsDriver);
            ...
        }
        private void WillsCustomerDetail(WillsDriver driver)
        {
            driver.CustomerDetail.MainCustomer.Title = "Dr";
            driver.CustomerDetail.MainCustomer.Gender = "Male";
            driver.CustomerDetail.MainCustomer.Name = "Liufa";
            driver.CustomerDetail.MainCustomer.Surname = "Afuil";
            driver.CustomerDetail.MainCustomer.DateOfBirth = new DateTime(1955, 12, 26);
            ...
            driver.CustomerDetail.ClickContinue();
        }
    public class WillsDriver
    {
        public WillsDriver(IWebDriver driver)
        {
            this.Driver = driver;
            this.Index = new IndexClass(driver);
            this.Quote = new QuoteClass(driver);
            this.CustomerDetail = new CustomerDetailsClass(driver);
        }
        public CustomerDetailsClass CustomerDetail { get; private set; }
        public IndexClass Index { get; private set; }
        public QuoteClass Quote { get; private set; }
        public IWebDriver Driver { get; set; }
        ....
        public class CustomerDetailsClass
        {
            public CustomerDetailsClass(IWebDriver driver)
            {
                this.Driver = driver;
                this.MainCustomer = new MainCustomerClass(driver);
                this.SecondCustomer = new SecondCustomerClass(driver);
            }
            public IWebDriver Driver { get; set; }
            public MainCustomerClass MainCustomer { get; private set; }
            public SecondCustomerClass SecondCustomer { get; private set; }
            ....
            public class MainCustomerClass
            {
                public MainCustomerClass(IWebDriver driver)
                {
                    this.Driver = driver;
                }
                public IWebDriver Driver { get; set; }
                public string Title
                {
                    set
                    {
                        this.Driver.SetDropDown(value, WillsElements.CustomerDetails.MainCustomer.Title);
                        if (value == "Dr") Thread.Sleep(700);
                    }
                }
           ....
          }
     }
   
    public class WillsElements
    {
        public static class CustomerDetails
        {
            public static class MainCustomer
            {
                public static string Title
                {
                    get { return "#Customers-0--Title"; }
                }
                public static string Gender
                {
                    get { return "#Customers-0--GenderSection-Gender"; }
                }
                public static string Firstname
                {
                    get { return "#Customers-0--Firstname"; }
                }
        ....
        }
    }
    public static class SetWillElement
    {
        public static IWebElement SetDropDown(this IWebDriver driver, string value, string selector)
        {
            var element = driver.FindElement(By.CssSelector(selector));
            var select = new SelectElement(element);
            select.SelectByText(value);
            return element;
        }
        public static string YesNoToCssSelector(this string name, string value)
        {
            return string.Format("{0}[value='{1}']", name, value == "Yes" ? "True" : "False");
        }
        public static IWebElement ClickButton(this IWebDriver driver, string selector)
        {
            var element = driver.FindElement(By.CssSelector(selector));
            element.Click();
            return element;
        }
        public static IWebElement SetRadio(this IWebDriver driver, string value, string selector)
        {
            var element = driver.FindElement(By.CssSelector(selector));
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].checked = true;", element);
            return element;
        }
        public static IWebElement SetText(this IWebDriver driver, string value, string selector)
        {
            var element = driver.FindElement(By.CssSelector(selector));
            element.SendKeys(value);
            return element;
        }
    }
