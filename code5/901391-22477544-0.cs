      '--- Compute arc center from radius
      Dim tang#, w#
      tang = co1.Tangent(co2)
      co2.Rotate co1, -tang
      center.X = (co1.X + co2.X) / 2
      center.Y = 0
      w = center.X - co1.X
      If Abs(mModal.RWord) < w Then
        '--- R-word too small
        If mModal.ThrowErr And w - Abs(mModal.RWord) > 0.00
          Err.Raise 911, , "R-word too small"
        End If
      Else
        center.Y = -Sqr(mModal.RWord * mModal.RWord - w * w
      End If
      '--- Choose out of the 4 possible arcs
      If Not cw Then center.Y = -center.Y
      If mModal.RWord < 0 Then center.Y = -center.Y
      center.Y = center.Y + co1.Y
      center.Rotate co1, tang
      co2.Rotate co1, tang
      GetArcCenter = center
