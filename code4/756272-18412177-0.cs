    Public Class  MyCoorSpace 
     inherits CoordinateSpace
    
    
    
    Public Overrides Function ToPixelsY(ByVal y As Single) As Single
        Return MyBase.FromPixelsY(y)
    End Function  
    
    End Class
    
