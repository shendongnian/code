    double sum = 0;
    var syncObj = new object();
    Parallel.For<double>(0, this.Count, () => 0, (i, loop, sub) =>
        {
            var innerList = this[i];
            for (int j = 0; j < innerList.Count; j++)
            {
                sub += innerList[j];
            }
            return sub;
        },
        (x) => 
            {
                lock(syncObj)
                   sum += x;
            });
    return sum / ((this.Count * this[0].Count));
