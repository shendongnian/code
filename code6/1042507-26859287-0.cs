    string a= "6,9"; string b= "5,9";
    char[] splitters = new[] { ',', ' '};
    var aList = a.Split(splitters);
    var bList = b.Split(splitters);
    var uniqueA = aList.Except(bList).ToList();
    var uniqueB = bList.Except(aList).ToList();
