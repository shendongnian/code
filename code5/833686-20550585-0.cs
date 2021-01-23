    public void PlotPoints(float[] x, float[] y, float[] z) {
        using (ILScope.Enter()) {
            ILArray<float> starPositions = ILMath.zeros<float>(3, x.Length);
            starPositions["0;:"] = x;
            starPositions["1;:"] = y;
            starPositions["2;:"] = z;
            ilPanel1.Scene.First<ILPlotCube>().Add<ILPoints>(new ILPoints { Positions = starPositions });
            // (... or update accordingly, if the shape exists already)
            // at the end of all modifications, call Configure()
            ilPanel1.Scene.Configure(); 
            ilPanel1.Refresh();
        }
    }
