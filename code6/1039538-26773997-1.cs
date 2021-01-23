        /// <summary>
        /// Returns JavaScript XPath query string for getting a single element 
        /// </summary>
        /// <param name="xpath">Any valid XPath string, for example "//input[@id='myid']"</param>
        /// <returns>JS code to perform the XPath query (document.evaluate(...)</returns>
        public static string GetJsSingleXpathString(string xpath)
        {
            return
                String.Format(
                    "document.evaluate(\"{0}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue", xpath);
        }
        private void Reload_Tick(object sender, EventArgs e)
        {
            string jsXpath = GetJsSingleXpathString("//a[contains(@class, 'Reload')]");
            Event(jsXpath, "click");
        }
