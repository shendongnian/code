        // define the delegate
        public delegate void ProcessResultDelegate(Product result, Part interestingPart);
        // an example search function
        public static void RunSearch(IEnumerable<Product> products, ProcessResultDelegate processingHelper)
        {
            // run the search... then call the processing function
            processingHelper(searchResult, interestingPart);
        }
