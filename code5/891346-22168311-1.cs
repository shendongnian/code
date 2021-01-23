	Imports System.Collections.ObjectModel
	Class MainWindow
		Public Sub New()
			InitializeComponent()
			Me.DataContext = New ObservableCollection(Of DummyClass)(Enumerable.Range(0, 10).Select(Function(a) New DummyClass() With {.Title = "Dummy Title: " & a}))
		End Sub
	End Class
	Public Class DummyClass
		Property Title As String
	End Class
	Public Class StringToBooleanConverter
		Implements IValueConverter
		Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
			Dim strValue = System.Convert.ToString(value)
			If String.IsNullOrEmpty(strValue) Then
				Return False 'Unchecked
			End If
			If strValue = "checked" Then
				Return True 'checked
			End If
			Return False 'default
		End Function
		Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
	End Class
