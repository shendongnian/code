    Imports System.Globalization
    Imports System.Windows.Data
    Imports System.Collections.ObjectModel
    
    Public Class SelectedValueIgnoreCaseConverter
        Implements IMultiValueConverter
    
        Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
            Dim selectedValue As String = TryCast(values(0), String)
            Dim options As ObservableCollection(Of String) = TryCast(values(1), ObservableCollection(Of String))
    
            If selectedValue Is Nothing Or options Is Nothing Then
                Return Nothing
            End If
    
            options.Contains(selectedValue, StringComparer.OrdinalIgnoreCase)
            Dim returnValue As String = Utilities.Conversions.ParseNullToString((From o In options Where String.Equals(selectedValue, o, StringComparison.OrdinalIgnoreCase)).FirstOrDefault)
    
            Return returnValue
        End Function
    
        Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
            Dim result(2) As Object
            result(0) = value
            Return result
        End Function
    End Class
