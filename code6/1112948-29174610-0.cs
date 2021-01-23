       Public Class ToolTipToSourceConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            If value Is Nothing Then
                Return "Error "
            End If
            Try
                Dim sndr = DirectCast(value, MahApps.Metro.Controls.Tile)
                Dim sndrimage = DirectCast(sndr.GetChildObjects(False)(0), Image)
                Dim imgname As String = sndrimage.Source.ToString.Substring(sndrimage.Source.ToString.LastIndexOf("/"c) + 1)
                Return StatsDict.InquireForAssignment(imgname).Name.ToString.Replace("_", " ")
            Catch ex As Exception
                Return value.GetType.ToString
            End Try
            'if is connected to master True then hide
        End Function
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException
        End Function
    End Class
