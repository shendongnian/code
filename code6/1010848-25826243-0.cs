    Public NotInheritable Class SocketAwaitable
    	Implements INotifyCompletion
    
    	Private ReadOnly Shared SENTINEL As Action = Sub()
    	End Sub
    
    	Friend m_wasCompleted As Boolean
    	Friend m_continuation As Action
    	Friend m_eventArgs As SocketAsyncEventArgs
    
    	Public Sub New(ByVal eventArgs As SocketAsyncEventArgs)
    		If eventArgs Is Nothing Then
    			Throw New ArgumentNullException("eventArgs")
    		End If
    		m_eventArgs = eventArgs
    		AddHandler eventArgs.Completed, Sub()
    			Dim prev = If(m_continuation, Interlocked.CompareExchange(m_continuation, SENTINEL, Nothing))
    			If prev IsNot Nothing Then
    				prev()
    			End If
    		End Sub
    	End Sub
    
    	Friend Sub Reset()
    		m_wasCompleted = False
    		m_continuation = Nothing
    	End Sub
    
    	Public Function GetAwaiter() As SocketAwaitable
    		Return Me
    	End Function
    
    	Public ReadOnly Property IsCompleted() As Boolean
    		Get
    			Return m_wasCompleted
    		End Get
    	End Property
    
    	Public Sub OnCompleted(ByVal continuation As Action)
    		If m_continuation Is SENTINEL OrElse Interlocked.CompareExchange(m_continuation, continuation, Nothing) Is SENTINEL Then
    			Task.Run(continuation)
    		End If
    	End Sub
    
    	Public Sub GetResult()
    		If m_eventArgs.SocketError <> SocketError.Success Then
    			Throw New SocketException(CInt(Math.Truncate(m_eventArgs.SocketError)))
    		End If
    	End Sub
    End Class
