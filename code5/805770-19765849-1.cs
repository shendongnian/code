     private readonly XNamespace dataNamspace = "urn:ietf:params:xml:ns:icalendar-2.0";
        public void webClient_OpenReadCompleted(object sender,
                                                OpenReadCompletedEventArgs e)
        {
            XDocument unmXdoc = XDocument.Load(e.Result, LoadOptions.None);
            this.Items = from p in unmXdoc.Descendants(dataNamspace + "vevent").Elements(dataNamspace + "properties")
                         select new ItemViewModel
                {
                    LineOne = this.GetElementValue(p, "summary"),
                    LineTwo = this.GetElementValue(p, "description"),
                    LineThree = this.GetElementValue(p, "categories"),
                };
            lstData.ItemsSource = this.Items;
        }
        private string GetElementValue(XElement element, string fieldName)
        {
            var childElement = element.Element(dataNamspace + fieldName);
            return childElement != null ? childElement.Value : String.Empty;
        }
