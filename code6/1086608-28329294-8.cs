    public static class TestClass
    {
        public static void Test()
        {
            //string url = @"d:\temp\question28328432.json";
            string url = @"http://steamcommunity.com/id/Mambocsgoshack/inventory/json/730/2/";
            var inventory = CSGOInventory.FetchInventoryFromUrl(new Uri(url));
            foreach (var market in inventory.MarketNames)
            {
                Console.WriteLine(string.Format("    Market {0,-50}: id {1}", market, inventory.getInstanceIdFromMarketName(market)));
            }
        }
    }
