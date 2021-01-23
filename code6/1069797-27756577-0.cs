    static dynamic GetRates()
    {
        List<double> SumList = new List<double>();
        List<double> List = new List<double>();
        var Items = new { sumList = SumList, ratesList = List, sum = List.Sum() };
        return Items;
    }
    static void Main(string[] args)
    {
        dynamic res = GetRates();
        List<double> MashkantaSumList = res.sumList;
    }
