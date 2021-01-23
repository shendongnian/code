    Public Class  MyCoordSpace // here of course would be nice to implement same interface as CoordinateSpace, if any 
 
        private  _cs as new CoordinateSpace()
    Public Function ToPixelsY(ByVal y As Single) As Single
        Return _cs.FromPixelsY(y)
    End Function  
    End Class
