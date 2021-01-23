    Imports System.Threading.Tasks
    
    Public Class Service1
    
        Private tasks As New List(Of Task)
    
        Protected Overrides Sub OnStart(ByVal args() As String)
            tasks.Add(Task.Factory.StartNew(Sub() DoWork()))
        End Sub
    
        Private Sub DoWork()
            ' Do long running work
        End Sub
    
        Protected Overrides Sub OnStop()
            Task.WaitAll(tasks.ToArray())
        End Sub
    
    End Class
