    private void ilPanel1_Load(object sender, EventArgs e) {
        var scene = new ILScene();
        // add a new plot cube 
        var pc = scene.Add(new ILPlotCube(twoDMode:false));
        // Create Data
        ILArray<float> A = ILSpecialData.torus(0.75f, .25f);
        ILArray<float> B = ILSpecialData.torus(3.0f, .65f);
        // Add the surfaces
        var cdr = Tuple.Create<float,float>(-0.6f, 0.6f);  
        var sf1 = new ILSurface(0);
        var sf2 = new ILSurface(0);
        // provide the same datarange to both surfaces
        sf1.UpdateColormapped(A, dataRange: cdr);
        sf2.UpdateColormapped(B, dataRange: cdr);
        pc.Add(sf1);
        pc.Add(sf2);
        sf1.Colormap = Colormaps.Jet;
        sf2.Colormap = Colormaps.Jet;
        var cb = new ILColorbar() {
            Padding = new SizeF(10,30),
            Children = {
                new ILLabel("Title") {
                    Position = new Vector3(.5f,.1f,0),
                    Anchor = new PointF(.5f,.7f),
                    Font = new Font(DefaultFont, FontStyle.Bold)
                },
                new ILLabel("Label") {
                    Position = new Vector3(.12f,.5f,0),
                    Rotation = -Math.PI / 2,
                }
            }
        };
        sf1.Add(cb);
        ilPanel1.Scene = scene;
    }
