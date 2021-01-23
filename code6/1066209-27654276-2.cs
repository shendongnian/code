    Public Class ProgressBarColumn
	Inherits GridViewDataColumn
	Public Sub New(fieldName As String)
		MyBase.New(fieldName)
	End Sub
	Public Overrides Function GetCellType(row As GridViewRowInfo) As Type
		If TypeOf row Is GridViewDataRowInfo Then
			Return GetType(ProgressBarCellElement)
		End If
		Return MyBase.GetCellType(row)
	End Function
    End Class
