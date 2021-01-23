    Public Class Something
    
      Public Property Items As Dictionary(Of DateTime, String)
    
      Public Readonly Property FormattedItem(ByVal index As Int32) As String
        ' add error checking/handling as appropriate
        Return Me.Items.Keys(index).ToString("custom format")  '  or whatever your formatting function looks like.
      End Property
    End Class
