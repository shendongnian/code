    public class PointAndAngle
    {
        public Point Point { get; set; }
        public Angle Angle { get; set; }
    }
    
    var pAndA = new PointAndAngle { Point = p, Angle = a };
    return Json(pAndA);
