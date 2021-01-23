    public bool GraphicsPath.IsOutlineVisible(PointF pt, Pen pen, Graphics graphics)
    {
      int num;
      if (pen == null)
      {
          throw new ArgumentNullException("pen");
      }
      int status = SafeNativeMethods.Gdip.GdipIsOutlineVisiblePathPoint(new HandleRef(this, this.nativePath), pt.X, pt.Y, new HandleRef(pen, pen.NativePen), new HandleRef(graphics, (graphics != null) ? graphics.NativeGraphics : IntPtr.Zero), out num);
      if (status != 0)
      {
          throw SafeNativeMethods.Gdip.StatusException(status);
      }
      return (num != 0);
    }
