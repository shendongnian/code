        Dim NumThreads As Integer = 10
        Dim CanTokSrc As New CancellationTokenSource
        Dim LongRunningTasks As Task() = New Task(NumThreads) {}
        Dim i As Integer
        Do Until i = LongRunningTasks.Count
            LongRunningTasks(i) = Task.Factory.StartNew(Sub()
                                                            Do Until CanTokSrc.IsCancellationRequested
                                                                'DO WORK HERE
                                                            Loop
                                                        End Sub, CanTokSrc.Token, TaskCreationOptions.LongRunning)
            i = i + 1
        Loop
