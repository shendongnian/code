    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
     
    namespace Blog.Example
    {
        [CodedUITest]
        public class SimpleUITestWithoutCodedUI
        {
            [TestMethod]
            public void SimpleWebTest()
            {
                //open the default browser and navigate to a web page - blog.falafel.com
                BrowserWindow browser = BrowserWindow.Launch(new Uri("http://blog.falafel.com"));
                //we can use controls as a way to narrow down the search for other controls
                var headerSection = browser.SearchFor<HtmlCustom>(new { TagName = "HEADER" });
                //let's search for something
                var searchIcon = headerSection.SearchFor<HtmlHyperlink>(new { href = "http://blog.falafel.com/#searchbox" });
                Mouse.Click(searchIcon);
                var searchInput = browser.SearchFor<HtmlEdit>(new { name = "s" }, new { type = "INPUT" });
                searchInput.Text = "treats and tricks";
                Keyboard.SendKeys("{ENTER}");
                //find our searched for item
                var postToLookFor = browser.SearchFor<HtmlCustom>(new { TagName = "ARTICLE" }, new { InnerText = "31 Days of Visual Studio 2015 Tricks and Treats Blog Post" });
                //validate our search
                Assert.IsTrue(postToLookFor.Exists);
            }
        }
    }
