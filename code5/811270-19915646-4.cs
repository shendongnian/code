    var list = new[] { 80,81,90,90,90,90,90,90,100,85,86,86,79,95,95,95,95 };
    var dupes = new List<int>();
    int? prev = null;
    for(var i = 2; i < list.Length; i++) {
        if(list[i] == list[i - 1] && list[i] == list[i - 2]) {
            if(!prev.HasValue || prev.Value != list[i]) {
                dupes.Add(list[i]);
                prev = list[i];
            }
        }
    }
