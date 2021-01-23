    <%@ Page Language="C#" ContentType="image/jpeg" %>
    <%@ Import Namespace="System.Drawing" %>
    <%@ Import Namespace="System.Drawing.Text" %>
    <%@ Import Namespace="System.Drawing.Imaging" %>
    <%@ Import Namespace="System.Drawing.Drawing2D" %>
    <%
        Response.Clear();
    int[,] A = new [,] {
    {1, 1, 1, 1, 2, 2},
    {1, 1, 1, 1, 2, 2},
    {1, 1, 1, 1, 2, 2},
    {1, 1, 1, 1, 0, 0},
    {3, 3, 3, 3, 3, 0},
    {3, 3, 3, 3, 3, 0},
    {0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0}
    };
    int[,] data = A; 
    // Do everything as like with the bitmap:
    //  show it up, e.g. myPictureBox.Image = result;
    //  save it to the file...
    // Possible brushes (fill yourself)
    Brush[] brushes = new Brush[] {
    Brushes.Red,     // <- color for 0
    Brushes.Green,   // <- color for 1
    Brushes.Blue,    // <- color for 2
    Brushes.Yellow,  // <- ...
    Brushes.Cyan
    };
    // Let resulting bitmap be about 200x200
    int step_x = 200 / (data.GetUpperBound(1) - data.GetLowerBound(1));
    int step_y = 200 / (data.GetUpperBound(0) - data.GetLowerBound(0));
    Bitmap result = new Bitmap((data.GetUpperBound(1) - data.GetLowerBound(1) + 1) * step_x,
                             (data.GetUpperBound(0) - data.GetLowerBound(0) + 1) * step_y);
    using (Graphics gc = Graphics.FromImage(result)) {
    for (int i = data.GetLowerBound(0); i <= data.GetUpperBound(0); ++i)
      for (int j = data.GetLowerBound(1); j <= data.GetUpperBound(1); ++j) {
        int v = data[i, j];
        gc.FillRectangle(brushes[v % brushes.Length], new Rectangle(j * step_x, i * step_y,     step_x, step_y));
      }
    }
    result.Save(Response.OutputStream, ImageFormat.Jpeg);
    result.Dispose();
    Response.End();
    %>
