    List<InvestmentReturnElement> profitElements = new List<InvestmentReturnElement>();
    var salesProfitBook = new RetailProfit(bookShop1);
    var salesProfitAudioCD = new RetailProfit(cd1Shop);
    var intellectualProfitEngineDesign = new IntellectualRightsProfit(enginePatent);
    var intellectualProfitBenzolMedicine = new IntellectualRightsProfit(medicinePatent);
    profitElements.Add(salesProfitBook);
    profitElements.Add(salesProfitAudioCD);
    profitElements.Add(intellectualProfitEngineDesign);
    profitElements.Add(intellectualProfitBenzolMedicine);
    foreach (var profitelement in profitElements)
    {
        Console.WriteLine("Profit: {0:c}", profitelement.GetInvestmentProfit());
    }
    Console.ReadKey();
