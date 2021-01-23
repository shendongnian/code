    Public Class XWizardPage
        Inherits DevExpress.XtraEditors.XtraPanel
        Implements IComparable(Of XWizardPage)
        Protected Overrides Sub OnResize(e As System.EventArgs)
            MyBase.OnResize(e)
            If (Not Me.positioningInternal) Then Me.Position()
        End Sub
        Protected Overrides Sub SetBoundsCore(x As Integer, y As Integer, width As Integer, height As Integer, specified As System.Windows.Forms.BoundsSpecified)
            MyBase.SetBoundsCore(x, y, width, height, specified)
            If (Not Me.positioningInternal) Then Me.Position()
        End Sub
        Protected Overrides Sub OnParentChanged(e As System.EventArgs)
            MyBase.OnParentChanged(e)
            If (Not Me.cachedParent Is Nothing) Then
                RemoveHandler Me.cachedParent.SizeChanged, AddressOf Me.OnParentSizeChanged
            End If
            Me.cachedParent = If(((Not Me.Parent Is Nothing) AndAlso (TypeOf Me.Parent Is XWizardControl)), Me.Parent, Nothing)
            If (Not Me.cachedParent Is Nothing) Then
                AddHandler Me.cachedParent.SizeChanged, AddressOf Me.OnParentSizeChanged
            End If
        End Sub
        Private Sub OnParentSizeChanged(sender As Object, e As EventArgs)
            Me.Position()
        End Sub
        Private Sub Position()
            If (Not Me.cachedParent Is Nothing) Then
                Dim r As Rectangle = Me.cachedParent.ClientRectangle
                r.Y += 10
                r.Height -= (10 * 2)
                If (Me.Bounds <> r) Then
                    Me.positioningInternal = True
                    Me.Bounds = r
                    Me.positioningInternal = False
                End If
            End If
        End Sub
        Private cachedParent As Control
        Private positioningInternal As Boolean
    End Class
