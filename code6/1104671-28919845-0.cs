    Private Sub Worksheet_Change(ByVal Target As Range)
        Dim KeyCells As Range
    
        ' The variable KeyCells contains the cells that will
        ' cause an alert when they are changed.
        Set KeyCells = Range("A1:C10")
        
        If Not Application.Intersect(KeyCells, Range(Target.Address)) _
               Is Nothing Then
    
            ' Display a message when one of the designated cells has been 
            ' changed.
            ' Place your code here.
            MsgBox "Cell " & Target.Address & " has changed."
           
        End If
    End Sub
