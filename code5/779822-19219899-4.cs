    Public Class BooleanDateConverter
        Implements System.Windows.Data.IValueConverter
        Public Function Convert(ByVal value As Object,
                                ByVal targetType As System.Type,
                                ByVal parameter As Object,
                                ByVal culture As System.Globalization.CultureInfo) _
                 As Object Implements System.Windows.Data.IValueConverter.Convert
            If DirectCast(value, Boolean) Then
                Return New System.Windows.Media.SolidColorBrush(
                   System.Windows.Media.Color.FromArgb(170, 102, 255, 245))
            Else
                Return New System.Windows.Media.SolidColorBrush(
                   System.Windows.Media.Color.FromArgb(170, 255, 0, 0))
            End If
        End Function
        Public Function ConvertBack(ByVal value As Object,
                            ByVal targetType As System.Type,
                            ByVal parameter As Object,
                            ByVal culture As System.Globalization.CultureInfo) _
        As Object Implements System.Windows.Data.IValueConverter.ConvertBack
            Return Nothing
        End Function
    End Class
