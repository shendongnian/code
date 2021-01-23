    const N = 5;  // Number of input lines.
    var info = new NavigationInfo[N];  // Here an array is handier as individual variables.
    for (int i = 0; i < N; i++) {
         // You don't need any index here, you can reuse the same variable.
        string input = Console.ReadLine();
        // Same here. You can resuse this array.
        string[] parts = input.Split(',');
        var navInfo = new NavigationInfo(parts[0], parts[1], parts[2], parts[3],
                                         Convert.ToDouble(parts[4]));
        navInfo.calculateDistance();
        navInfo.calculateTime();
        navInfo.calculateCost();
        info[i] = navInfo;
    }
    for (int i = 0; i < N; i++) {
        Console.WriteLine(info[i]);  // Console.WriteLine calls ToString automatically.
    }
