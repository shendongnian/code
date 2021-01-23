    Public Class Ant
       public position as vector2
       public health as integer = 100
       public isdead ad boolean = false
    End class
    
    Public Class Ants
       Inherit list (of Ant)
    
       Public Sub AddAnt(Position)
       // add new ant to list
       End Sub
    
       Public Sub Update()
        For Each ant As ant In ants
          If Not(ant.isdead)
            // update ants
          End If
        Next
    
        Me.RemoveAll(function(c) c.isdead = true)
    
       End Sub
    
       Public Sub Draw()
         For Each ant As ant In ants
          If not(ant.isdead)
            // draw ants
          End If        
         Next
       End Sub
    
    End class
