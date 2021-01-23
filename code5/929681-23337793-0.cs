    private void ilPanel1_Load(object sender, EventArgs e) {
        ilpanel1.Scene.Camera.Add(Shapes.UnitCubeFilled);
        ilpanel1.Scene.Camera.Add(Shapes.UnitCubeWireframe);
        ilpanel1.Scene.First<ILTriangles>().AutoNormals = false; 
        ilpanel1.Configure();
    }
