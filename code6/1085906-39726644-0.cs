    Imports System.Threading
    Imports System.Runtime.CompilerServices
    
    Public Class Form1
    
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            SyncMethod()
        End Sub
    
        ' waiting inside Sync method for finishing async method
        Public Sub SyncMethod()
            Dim sc As New SC
            sc.WaitForTask(AsyncMethod())
            sc.Release()
        End Sub
    
        Public Async Function AsyncMethod() As Task(Of Boolean)
            Await Task.Delay(1000)
            Return True
        End Function
    
    End Class
    
    Public Class SC
        Inherits SynchronizationContext
    
        Dim OldContext As SynchronizationContext
        Dim ContextThread As Thread
    
        Sub New()
            OldContext = SynchronizationContext.Current
            ContextThread = Thread.CurrentThread
            SynchronizationContext.SetSynchronizationContext(Me)
        End Sub
    
        Dim DataAcquired As New Object
        Dim WorkWaitingCount As Long = 0
        Dim ExtProc As SendOrPostCallback
        Dim ExtProcArg As Object
    
        <MethodImpl(MethodImplOptions.Synchronized)>
        Public Overrides Sub Post(d As SendOrPostCallback, state As Object)
            Interlocked.Increment(WorkWaitingCount)
            Monitor.Enter(DataAcquired)
            ExtProc = d
            ExtProcArg = state
            AwakeThread()
            Monitor.Wait(DataAcquired)
            Monitor.Exit(DataAcquired)
        End Sub
    
        Dim ThreadSleep As Long = 0
    
        Private Sub AwakeThread()
            If Interlocked.Read(ThreadSleep) > 0 Then ContextThread.Resume()
        End Sub
    
        Public Sub WaitForTask(Tsk As Task)
            Dim aw = Tsk.GetAwaiter
    
            If aw.IsCompleted Then Exit Sub
    
            While Interlocked.Read(WorkWaitingCount) > 0 Or aw.IsCompleted = False
                If Interlocked.Read(WorkWaitingCount) = 0 Then
                    Interlocked.Increment(ThreadSleep)
                    ContextThread.Suspend()
                    Interlocked.Decrement(ThreadSleep)
                Else
                    Interlocked.Decrement(WorkWaitingCount)
                    Monitor.Enter(DataAcquired)
                    Dim Proc = ExtProc
                    Dim ProcArg = ExtProcArg
                    Monitor.Pulse(DataAcquired)
                    Monitor.Exit(DataAcquired)
                    Proc(ProcArg)
                End If
            End While
    
        End Sub
    
         Public Sub Release()
             SynchronizationContext.SetSynchronizationContext(OldContext)
         End Sub
    
    End Class
