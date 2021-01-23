    public class RemoteWebDriver : IWebDriver, IDisposable, ISearchContext, IJavaScriptExecutor, IFindsById, IFindsByClassName, IFindsByLinkText, IFindsByName, IFindsByTagName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, IHasInputDevices, IHasCapabilities, IAllowsFileDetection
    {
        protected static readonly TimeSpan DefaultCommandTimeout;
        public RemoteWebDriver(ICapabilities desiredCapabilities);
        public RemoteWebDriver(ICommandExecutor commandExecutor, ICapabilities desiredCapabilities);
        public RemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities);
        public RemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities, TimeSpan commandTimeout);
        public ICapabilities Capabilities { get; }
        protected ICommandExecutor CommandExecutor { get; }
        public string CurrentWindowHandle { get; }
        public virtual IFileDetector FileDetector { get; set; }
        public IKeyboard Keyboard { get; }
        public IMouse Mouse { get; }
        public string PageSource { get; }
        protected SessionId SessionId { get; }
        public string Title { get; }
        public string Url { get; set; }
        public ReadOnlyCollection<string> WindowHandles { get; }
        public void Close();
        protected virtual RemoteWebElement CreateElement(string elementId);
        public void Dispose();
        protected virtual void Dispose(bool disposing);
        protected virtual Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters);
        public object ExecuteAsyncScript(string script, params object[] args);
        public object ExecuteScript(string script, params object[] args);
        public IWebElement FindElement(By by);
        protected IWebElement FindElement(string mechanism, string value);
        public IWebElement FindElementByClassName(string className);
        public IWebElement FindElementByCssSelector(string cssSelector);
        public IWebElement FindElementById(string id);
        public IWebElement FindElementByLinkText(string linkText);
        public IWebElement FindElementByName(string name);
        public IWebElement FindElementByPartialLinkText(string partialLinkText);
        public IWebElement FindElementByTagName(string tagName);
        public IWebElement FindElementByXPath(string xpath);
        public ReadOnlyCollection<IWebElement> FindElements(By by);
        protected ReadOnlyCollection<IWebElement> FindElements(string mechanism, string value);
        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className);
        public ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector);
        public ReadOnlyCollection<IWebElement> FindElementsById(string id);
        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText);
        public ReadOnlyCollection<IWebElement> FindElementsByName(string name);
        public ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText);
        public ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName);
        public ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath);
        public IOptions Manage();
        public INavigation Navigate();
        public void Quit();
        protected virtual void StartClient();
        protected void StartSession(ICapabilities desiredCapabilities);
        protected virtual void StopClient();
        public ITargetLocator SwitchTo();
    }
