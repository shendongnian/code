    Class ProgressBarCellElement
	Inherits GridDataCellElement
	Private radProgressBarElement As RadProgressBarElement
	Public Sub New(column As GridViewColumn, row As GridRowElement)
		MyBase.New(column, row)
	End Sub
	Protected Overrides Sub CreateChildElements()
		MyBase.CreateChildElements()
		radProgressBarElement = New RadProgressBarElement()
		Me.Children.Add(radProgressBarElement)
	End Sub
	Protected Overrides Sub SetContentCore(value As Object)
		If Me.Value IsNot Nothing AndAlso Me.Value <> DBNull.Value Then
			Me.radProgressBarElement.Value1 = Convert.ToInt32(Me.Value)
		End If
	End Sub
	Protected Overrides ReadOnly Property ThemeEffectiveType() As Type
		Get
			Return GetType(GridDataCellElement)
		End Get
	End Property
	Public Overrides Function IsCompatible(data As GridViewColumn, context As Object) As Boolean
		Return TypeOf data Is ProgressBarColumn AndAlso TypeOf context Is GridDataRowElement
	End Function
    End Class
