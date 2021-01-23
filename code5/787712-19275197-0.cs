    Public Class Report
      Public Property Header As Header
      Public Property LineItems As IEnumerable(Of LineItem)
      Public Property Footer As Footer
    End Class
    
    Public Class Header
      Public Property Name As String
      ' This probably isn't the best word choice because it is a type alias in VB
      Public Property [Date] As Date
    End Class
    
    
    Public Class LineItem
      Public Property PartNumber As Integer
      Public Property PartDescription As String
      Public Property NumberOfItems As Integer
      Public Property PerItemPrice As Decimal
      Public Property TotalPrice As Decimal
    End Class
    
    
    Public Class Footer
      Public Property TotalItemsCount As Integer
      Public Property TotalPrice As Decimal
    End Class
