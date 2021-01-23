    Imports System
    
    Public Class Test
    	Public Shared Sub Main()
    		Dim runningVB As Boolean
    		' Check to see if program is running on Visual Basic engine.
    		If scriptEngine = "VB" Then
        		runningVB = 16
        		If runningVB = True Then
        			Console.WriteLine("True")
        		End If
        		runningVB = 0
        		If runningVB = False Then
        			Console.WriteLine("False")
        		End If
    		End If
    	End Sub
    End Class
