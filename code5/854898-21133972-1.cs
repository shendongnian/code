    List<List<List<double>>> listVal = new List<List<List<double>>>(){
        new List<List<double>>{
            new List<double>(){1,1,3},
            new List<double>(){2,1,2},
            new List<double>(){1,2,3}
        },
        new List<List<double>>{
            new List<double>(){2,1,3},
            new List<double>(){2,4,2},
            new List<double>(){3,1,3}
        },
        new List<List<double>>{
            new List<double>(){4,1,1},
            new List<double>(){4,2,1},
            new List<double>(){4,3,1}
        }
    };
    List<List<List<double>>> listQ = new List<List<List<double>>>(){
            new List<List<double>>{
            new List<double>(){3,7,4},
            new List<double>(){8,15,23},
            new List<double>(){11,13,17}
        },
        new List<List<double>>{
            new List<double>(){90,3,7},
            new List<double>(){5,7,12},
            new List<double>(){7,14,21}
        },
        new List<List<double>>{
            new List<double>(){32,4,1},
            new List<double>(){55,12,8},
            new List<double>(){3,5,8}
        }
    };
        
        
    //Linq awesomeness
    var qry = listVal.SelectMany((l1, i0) =>
                    l1.SelectMany((l2, i1) =>
                        l2.Select((ele, i2) =>
                            new { i0, i1, i2, gVal = ele, qVal = listQ[i0][i1][i2] })))
                    .GroupBy(x => new { x.i0, x.i1, x.gVal }) // if you want to average across the innermost lists only 
                    //.GroupBy(x => x.gVal)                   //if you want to average acreoss the whole data
                    .SelectMany(x => x.Select(e => new { e.i0, e.i1, e.i2, avg = x.Average(y => y.qVal) }));
    foreach (var e in qry)
    {
        listQ[e.i0][e.i1][e.i2] = e.avg;
    }
