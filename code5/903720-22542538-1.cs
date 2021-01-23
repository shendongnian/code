    private void DrawHighlight(Graphics g, Point[] usePoints,
                               int brushSize, Color brushColor) {
      int useColor = System.Drawing.ColorTranslator.ToWin32(brushColor);
      IntPtr pen = CreatePen(PS_SOLID, brushSize, (uint)useColor);
      IntPtr hDC = g.GetHdc();
      IntPtr xDC = SelectObject(hDC, pen);
      SetROP2(hDC, R2_MASKPEN);
      for (int i = 1; i <= usePoints.Length - 1; i++) {
        Point p1 = usePoints[i - 1];
        Point p2 = usePoints[i];
        MoveToEx(hDC, p1.X, p1.Y, IntPtr.Zero);
        LineTo(hDC, p2.X, p2.Y);
      }
      SetROP2(hDC, R2_COPYPEN);
      SelectObject(hDC, xDC);
      DeleteObject(pen);
      g.ReleaseHdc(hDC);
    }
