    List<Holding> _hldListAuto = new List<Holding> {
        new Holding { FundCode = "ASDF" },
        new Holding { FundCode = "QWER" },
    };
    List<Holding> _hldListMan = new List<Holding> {
        new Holding { FundCode = "QWER" },
        new Holding { FundCode = "ZXCV" },
    };
    List<Holding> missingAuto = _hldListMan.Except(_hldListAuto, new Holding.Comparer()).ToList();
    List<Holding> missingMan = _hldListAuto.Except(_hldListMan, new Holding.Comparer()).ToList();
    foreach (var holding in missingAuto)
        Console.WriteLine("Missing Auto " + holding.FundCode);
    foreach (var holding in missingMan)
        Console.WriteLine("Missing Man " + holding.FundCode);
