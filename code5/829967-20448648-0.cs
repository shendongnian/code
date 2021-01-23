    var dic = new Dictionary<CheckBox, int>
    {
        { chkBasketball, 50000 },
        { chkFire, 500 },
        { chkMarble, 20000 },
        { chkSteel, 10000 },
        { chkGarage, 5000 },
    };
    
    int sum = dic.Where( x => x.Key.Checked ).Sum( x => x.Value );
