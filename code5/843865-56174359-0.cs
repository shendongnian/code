    ''' <summary> Reference to the awaiting task. </summary>
    ''' <value> The awaiting task. </value>
    Protected ReadOnly Property AwaitingTask As Threading.Tasks.Task
    ''' <summary> Reference to the Action task; this task status undergoes changes. </summary>
    Protected ReadOnly Property ActionTask As Threading.Tasks.Task
    ''' <summary> Reference to the cancellation source. </summary>
    Protected ReadOnly Property TaskCancellationSource As Threading.CancellationTokenSource
    ''' <summary> Starts the action task. </summary>
    ''' <param name="taskAction"> The action to stream the entities, which calls
    '''                           <see cref="StreamEvents(Of T)(IEnumerable(Of T), IEnumerable(Of Date), Integer, String)"/>. </param>
    ''' <returns> The awaiting task. </returns>
    Private Async Function AsyncAwaitTask(ByVal taskAction As Action) As Task
        Me._ActionTask = Task.Run(taskAction)
        Await Me.ActionTask '  Task.Run(streamEntitiesAction)
        Try
            Me.ActionTask?.Wait()
            Me.OnStreamTaskEnded(If(Me.ActionTask Is Nothing, TaskStatus.RanToCompletion, Me.ActionTask.Status))
        Catch ex As AggregateException
            Me.OnExceptionOccurred(ex)
        Finally
            Me.TaskCancellationSource.Dispose()
        End Try
    End Function
    ''' <summary> Starts Streaming the events. </summary>
    ''' <exception cref="InvalidOperationException"> Thrown when the requested operation is invalid. </exception>
    ''' <param name="bucketKey">            The bucket key. </param>
    ''' <param name="timeout">              The timeout. </param>
    ''' <param name="streamEntitiesAction"> The action to stream the entities, which calls
    '''                                     <see cref="StreamEvents(Of T)(IEnumerable(Of T), IEnumerable(Of Date), Integer, String)"/>. </param>
    Public Overridable Sub StartStreamEvents(ByVal bucketKey As String, ByVal timeout As TimeSpan, ByVal streamEntitiesAction As Action)
        If Me.IsTaskActive Then
            Throw New InvalidOperationException($"Stream task is {Me.ActionTask.Status}")
        Else
            Me._TaskCancellationSource = New Threading.CancellationTokenSource
            Me.TaskCancellationSource.Token.Register(AddressOf Me.StreamTaskCanceled)
            Me.TaskCancellationSource.CancelAfter(timeout)
            ' the action class is created withing the Async/Await function
            Me._AwaitingTask = Me.AsyncAwaitTask(streamEntitiesAction)
        End If
    End Sub
