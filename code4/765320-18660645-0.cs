    Public MustInherit Class TestUser
       Public Sub Print()
          Dim x As AbstractBase = CreateTest()
          x.PrintTest()
       End Sub
    
       Protected MustOverride Function CreateTest() As AbstractBase 'IMO the type name should really be AbstractTest not AbstractBase 
    
    End Class
