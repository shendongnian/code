    private void ilPanel1_Load(object sender, EventArgs e) {
        // 3 arbitrary points 
        float[,] A = new float[3, 3] { 
            { 1.0f, 2.0f, 3.0f }, 
            { 2.0f, 2.0f, 4.0f }, 
            { 2.0f, -2.0f, 2.0f } 
        };
        // construct a new plotcube and plot the points
        var scene = new ILScene {
            new ILPlotCube(twoDMode: false) {
                new ILPoints {
                    Positions = A,
                    Size = 4,
                }
            }
        };
        // Plane equation: this is derived from the concrete example points. In your 
        // real world app you will have to adopt the weights a,b and c to your points. 
        Func<float, float, float> zEval = (x, y) => {
            float a = 1, b = 0.5f, c = 1;
            return a * x + b * y + c; 
        }; 
        // find bounding box of the plot contents 
        scene.Configure(); 
        var limits = scene.First<ILPlotCube>().Plots.Limits; 
        // Construct the surface / plane to draw
        // The 'plane' will be a surface constructed from a 2x2 mesh only. 
        // The x/y coordinates of the corners / grid points of the surface are taken from 
        // the limits of the plots /points. The corresponding Z coordinates are computed 
        // by the zEval function. So we give the ILSurface constructor not only Z coordinates 
        // as 2x2 matrix - but an Z,X,Y Array of size 2x2x3
        ILArray<float> P = ILMath.zeros<float>(2, 2, 3);
        Vector3 min = limits.Min, max = limits.Max; 
        P[":;:;1"] = new float[,] { { min.X, min.X }, { max.X, max.X } };
        P[":;:;2"] = new float[,] { { max.Y, min.Y }, { max.Y, min.Y } };
        P[":;:;0"] = new float[,] { 
            { zEval(min.X, max.Y) , zEval(min.X, min.Y) }, 
            { zEval(max.X, max.Y) , zEval(max.X, min.Y) }, 
        };
        // create the surface, make it semitransparent and modify the colormap
        scene.First<ILPlotCube>().Add(new ILSurface(P) {
            Alpha = 0.6f, 
            Colormap = Colormaps.Prism
        }); 
        // give the scene to the panel
        ilPanel1.Scene = scene;
    }
