    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Chrome;
    
    namespace WindowsFormsChrome
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // download the chrome driver
                IWebDriver driver = new ChromeDriver(@"C:\Users\Downloads\chromedriver"); 
                driver.Navigate().GoToUrl("http://www.yahoo.com");
                IWebElement myField = driver.FindElement(By.Id("txtUserName"));
                myField.SendKeys("UserName");
                IWebElement myField = driver.FindElement(By.Id("txtPassword"));
                myField.SendKeys("Password");
                IWebElement myField = driver.FindElement(By.Id("btnLogin"));
                myField.click()
            }
         }
    }
