    void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
    {
      int x = 100;
      int y = 100;
      int z = 0;
      int width = 50;
      int height = 50;
      int depth= 10;
    
      DrawCube(x, y, z, width, height, depth, g);
    }
    
    private void DrawCube(int x, int y, int z, int width, int height, int depth, Steema.TeeChart.Drawing.Graphics3D g)
    {
      Rectangle r = new Rectangle(x, y, width, height);
      g.Cube(r, z, z + depth);
    }
