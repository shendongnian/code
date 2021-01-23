        public void NormalizeDataExample()
        {
            List<LoadedMarketData> AppleMarketData = GetMarketData("AAPL");
            List<LoadedMarketData> MicrosoftMarketData = GetMarketData("MSFT");
            List<LoadedMarketData> YahootMarketData = GetMarketData("YHOO");
            List<LoadedMarketData> MarketData = new List<LoadedMarketData>();
            MarketData.AddRange(AppleMarketData);
            MarketData.AddRange(MicrosoftMarketData);
            MarketData.AddRange(YahootMarketData);
            DataSet dataSet = new DataSet().Convert(MarketData, "Market DataSet");
            var analyst = new EncogAnalyst();
            var wizard = new AnalystWizard(analyst);
            wizard.Wizard(dataSet);
            var normalizer = new AnalystNormalizeDataSet(analyst);
            var normalizedData = normalizer.Normalize(dataSet);
     
        }
