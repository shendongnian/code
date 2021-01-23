    public class my_font_size {
       float size_Points;
       public float Size_Points {
         get { return size_Points;}
         set {
            if(size_Points != value){
              size_Points = value;
              OnSize_PointsChanged(EventArgs.Empty);
            }
         }
       }
       public event EventHandler Size_PointsChanged;
       protected virtual void OnSize_PointsChanged(EventArgs e){
         var handler = Size_PointsChanged;
         if(handler != null){
            handler(this, e);
         }
       }
    }
