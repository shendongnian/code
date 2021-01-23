        var plotCube = ilPanel1.Scene.First<ILPlotCube>();
    
        List<Tuple<double, string>> ticks = null;
    
        plotCube.Axes.XAxis.Ticks.TickCreationFuncEx = 
            (float min, float max, int qty, ILAxis axis, AxisScale scale) => {
                ticks = CreateUnixDateTicks(min, max, qty).ToList();
    
                return // return IEnumerable<ILTick> here!
        };
        // you should not need this
        //plotCube.Axes.XAxis.ScaleLabel.Visible = false; 
