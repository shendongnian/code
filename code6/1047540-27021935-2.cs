    var X = new List<int> { 14, 19, 24, 28, 33 };
    var Y = new List<int> { 90, 90, 132, 150, 170 };
    var indexes = Y.Select((element, index) => new {element, index})
                   .Where(item => item.element < 100)
                   .Select(item => item.index)
                   .OrderByDescending(i => i)
                   .ToList();
    foreach (var index in indexes)
    {
        X.RemoveAt(index);
        Y.RemoveAt(index);
    }
