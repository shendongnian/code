    private void UpdateRegion(){
      GraphicsPath polygon_path = new GraphicsPath(FillMode.Winding);
      polygon_path.AddPolygon(GetPoints(btnExam.ClientRectangle));
      btnExam.Region = new Region(polygon_path);
    }
    //SizeChanged event handler for your btnExam
    private void btnExam_SizeChanged(object sender, EventArgs e){
      UpdateRegion();
    }
    //Then you just need to change the size of your btnExam in Parent_Load
    private void Parent_Load(object sender, EventArgs e) {
      //The button should be square
      btnExam.SetBounds( btnExam.Location.X, btnExam.Location.Y, 100, 100); 
    }
