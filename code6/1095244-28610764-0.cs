    Public Shared Sub SpawnAndWait(ByVal actions As IEnumerable(Of System.Action))
        Dim list As List(Of System.Action) = actions.ToList(Of System.Action)()
        Dim handles(actions.Count(Of System.Action)()) As System.Threading.ManualResetEvent
        Dim i As Integer = 0
        While i < list.Count
            handles(i) = New System.Threading.ManualResetEvent(False)
            Dim item As System.Action = list(i)
            Dim manualResetEvent As System.Threading.ManualResetEvent = handles(i)
            Dim action As System.Action = Sub()
            Try
                item()
            Finally
                manualResetEvent.[Set]()
            End Try
            End Sub
            ThreadPool.QueueUserWorkItem(Sub(x As Object) action())
            i = i + 1
        End While
        WaitHandle.WaitAll(handles)
    End Sub
