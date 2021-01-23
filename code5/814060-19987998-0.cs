    private double Getslope(List<double> ProductGrossExcessReturnOverRFR, 
                            List<double> primaryIndexExcessReturnOverRFR, 
                            int months, 
                            int go_back = 0)
    {
        // calc # of items to skip
        int skip = ProductGrossExcessReturnOverRFR.Count - go_back - months;
        // get list of x's and y's
        var xs = ProductGrossExcessReturnOverRFR.Skip(skip).Take(months);
        var ys = primaryIndexExcessReturnOverRFR.Skip(skip).Take(months);
        // "zip" xs and ys to make the sum of products easier
        var xys = Enumerable.Zip(xs,ys, (x, y) => new {x = x, y = y});
        double xbar = xs.Average();
        double ybar = ys.Average();
        double slope = xys.Sum(xy => (xy.x - xbar) * (xy.y - ybar)) / xs.Sum(x => (x - xbar)*(x - xbar));
        return slope;
    }
