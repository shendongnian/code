    private void ilPanel1_Load(object sender, EventArgs e) {
        using (ILScope.Enter()) {
            // some 'input matrix'
            ILArray<float> Z = ILSpecialData.sincf(40, 50);
            // do some reordering: prepare vertices
            ILArray<float> Y = 1, X = ILMath.meshgrid(
                                ILMath.vec<float>(1, Z.S[1]), 
                                ILMath.vec<float>(1,Z.S[0]),
                                Y); 
            // reallocate the vertex positions matrix
            ILArray<float> pos = ILMath.zeros<float>(3, X.S.NumberOfElements); 
            // fill in values
            pos["0;:"] = X[":"]; 
            pos["1;:"] = Y[":"]; 
            pos["2;:"] = Z[":"]; 
            // colormap used to map the values to colors
            ILColormap cmap = new ILColormap(Colormaps.Hot);
            // setup the scene
            ilPanel1.Scene.Add(new ILPlotCube {
                new ILPoints() {
                    Positions = pos, 
                    Colors = cmap.Map(Z).T, 
                    Color = null
                }
            }); 
        }
    }
