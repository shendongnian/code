    Private Sub gridLeft_ManipulationDelta(sender As Object, e As ManipulationDeltaEventArgs) Handles gridLeft.ManipulationDelta
      
      Dim element As UIElement = TryCast(e.Source, UIElement)
      Dim xform As MatrixTransform = TryCast(element.RenderTransform, MatrixTransform)
      Dim matrix As Matrix = xform.Matrix
      Dim delta As ManipulationDelta = e.DeltaManipulation
      Dim center As Point = e.ManipulationOrigin
      matrix.Translate(-center.X, -center.Y)
      matrix.Scale(delta.Scale.X, delta.Scale.Y)
      matrix.Translate(center.X, center.Y)
      matrix.Translate(delta.Translation.X, delta.Translation.Y)
    
      If matrix.Determinant >= 2.0 Or matrix.Determinant <= 1.0 Then
         Return
      End If
      xform.Matrix = matrix
      e.Handled = True
      MyBase.OnManipulationDelta(e)
    End Sub
