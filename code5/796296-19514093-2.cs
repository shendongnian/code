    private void UpdateRegion(){
      GraphicsPath polygon_path = new GraphicsPath(FillMode.Winding);
      polygon_path.AddPolygon(GetPoints(btnExam.ClientRectangle));
      btnExam.Region = new Region(polygon_path);
    }
    //SizeChanged event handler for your btnExam
    private void btnExam_SizeChanged(object sender, EventArgs e){
      UpdateRegion();
    }
