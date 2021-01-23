    Imports System.Runtime.CompilerServices
    
    Public Module ComboBoxExtensions
    
        <Extension>
        Public Function ContainsItemText(source As ComboBox, itemText As String) As Boolean
            Return source.Items.Cast(Of Object).Any(Function(item) source.GetItemText(item) = itemText)
        End Function
    
    End Module
