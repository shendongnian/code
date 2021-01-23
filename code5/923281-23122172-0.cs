    var point = new PointF(100, 150);
    var center = new PointF(100, 100);
    var angle = 45;
    var rotateMat = Cv2.GetRotationMatrix2D(new Point2f(center.Y, center.X), angle, 1);
    var resultPoint = (rotateMat * point.ToMat()).ToMat().ToPointF();
    static class Hlp
    {
      public static PointF ToPointF(this Mat mat)
      {
        return new PointF((float)mat.Get<double>(1, 0), (float)mat.Get<double>(0, 0));
      }
      public static Mat ToMat(this PointF point)
      {
        return new Mat(3, 1, MatType.CV_64FC1, new double[] { point.Y, point.X, 1 });
      }
    }
