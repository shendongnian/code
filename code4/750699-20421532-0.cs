    public class QAS
    {
        public QAS()
        {       
            // Create a new soap proxy that can talk to QAS Pro Web   
            QuickAddress address = new QuickAddress("http://10.10.15.7:2021") 
            {
                Engine = QuickAddress.EngineTypes.Singleline,
                Flatten = true
            };
            this.searchService = address;
        }
        /// <summary>
        /// For the supplied search, get the moniker which can then be used to format the address.
        /// </summary>
        private string GetMoniker(string p)
        {
            return this.searchService.Search("GBR", p, PromptSet.Types.Default, "Database layout").Picklist.Items[0].Moniker;
        }
        /// <summary>
        /// Return a formatted address from the supplied search. 
        /// </summary>
        public string[] RefinePostcode(string p)
        {
            // Append the postcode to our address to speed up and improve searches.
            string search = p + "," + Postcode;
            SearchResult result = this.searchService.Search("GBR", 
                                                            postCode,
                                                            PromptSet.Types.OneLine,
                                                            "Database layout");
            if ( result.Picklist.Items.Length > 0 )
            {
            }
            else
            {
                // What is your workflow if an address is not found?
            }
            string moniker = this.GetMoniker(search);
            FormattedAddress formattedAddress = this.searchService.GetFormattedAddress(moniker, "Database Layout");
            return new string[] { formattedAddress.AddressLines[0].Line, formattedAddress.AddressLines[1].Line, formattedAddress.AddressLines[2].Line, formattedAddress.AddressLines[3].Line, formattedAddress.AddressLines[4].Line, formattedAddress.AddressLines[5].Line, formattedAddress.AddressLines[6].Line };
        }
        /// <summary>
        /// Once a postcode is captured by the operator, return a list of potential addresses. 
        /// </summary>
        public string[] SearchPostcodes(string postCode)
        {
            Postcode = postcode;
            SearchResult result = this.searchService.Search("GBR", 
                                                            postCode,
                                                            PromptSet.Types.OneLine,
                                                            "Database layout");
            string[] strArray = new string[result.Picklist.Length];
            for (int i = 0; i < result.Picklist.Length; i++)
            {
                strArray[i] = result.Picklist.Items[i].Text;
            }
            return strArray;
        }
        private QuickAddress searchService { get; set; }
   
        /// <summary>
        /// Gets or sets the postcode from the initial search.
        /// </summary>
        private string Postcode
        {
            get;
            set;
        }
    }
