    var output = new List<List<MyDate>>();
    int first = 0;
    while (first < list.Count) {
        var values = new List<MyDate>();
        values.Add(list[first]);
        int next = first+1;
        for ( ; next < list.Count; ++next) {
            if (list[next].Year * 12 + list[next].Month
                - (list[first].Year * 12 + list[first].Month) < 6) {
                values.Add(list[next]);
            } else {
                break;
            }
        }
        output.Add(values);
        first = next;
    }
