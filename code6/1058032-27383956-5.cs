    Public Class ItemStateConverter
        Inherits ExpandableObjectConverter
    
        Public Overrides Function ConvertTo(context As ITypeDescriptorContext,
                                   culture As Globalization.CultureInfo,
                                   value As Object, destinationType As Type) As Object
    
            If destinationType Is GetType(String) Then
                Dim item As ItemStateColors = CType(value, ItemStateColors)
    
                ' ToDo: decide the format of collapsed info            
                Return String.Format("{0}, {1}", item.EnabledBackColor.ToString,
                                     item.DisabledBackColor.ToString)
            End If
    
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
        
    End Class
