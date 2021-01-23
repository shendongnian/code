    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SikuliModule;
    using OpenQA.Selenium;
    namespace WordPressAutomation.DifferentTests
    {
        [TestClass]
    public class Sikuli
    {
        [TestMethod]
        public void TestMethod1()
        {
            driver.Initialize();
            driver.instance.Navigate().GoToUrl("https://www.google.co.in");
            SikuliAction.Click("E:/img.png");
        }
    }
    }
