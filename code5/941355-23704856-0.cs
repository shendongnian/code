            //Replace and make sure they are all added in order
            Single[] zs = [All Zs]
            Single[] xs = [All Xs]
            Single[] ys = [All Ys]           
            //create array of points               //something like below
            ILArray<float> points = ILMath.zeros<float>(xs.Length/s, s, 3);
            points[":;:;0"] = zs;
            points[":;:;1"] = xs;
            points[":;:;2"] = ys;            
            // construct a new plotcube and plot the points
            scene = new ILScene();
            cube = new ILPlotCube(twoDMode: false);
            surface = new ILSurface(points, colormap: Colormaps.Jet);
            //set scene properties
            scene.Add(cube);
            //display cube in scene
            ilPanel1.Scene = scene; 
