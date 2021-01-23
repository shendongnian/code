    #Region " Imports "
    
    Imports System.Threading
    Imports System.ComponentModel
    
    #End Region
    
    Namespace Common
    
        Public Class CmdShell
    
    #Region " Variables "
    
            Private WithEvents ShellProcess As Process
    
    #End Region
    
    #Region " Events "
    
            ''' <summary>
            ''' Event indicating an asyc read of the command process's StdOut pipe has occured.
            ''' </summary>
            Public Event DataReceived As EventHandler(Of CmdShellDataReceivedEventArgs)
    
    #End Region
    
    #Region " Public Methods "
    
            Public Sub New()
                ThreadPool.QueueUserWorkItem(AddressOf ShellLoop, Nothing)
                Do Until Not ShellProcess Is Nothing : Loop
            End Sub
    
            ''' <param name="Value">String value to write to the StdIn pipe of the command process, (CRLF not required).</param>
            Public Sub Write(ByVal value As String)
                ShellProcess.StandardInput.WriteLine(value)
            End Sub
    
    #End Region
    
    #Region " Private Methods "
    
            Private Sub ShellLoop(ByVal state As Object)
                Try
                    Dim SI As New ProcessStartInfo("cmd.exe")
                    With SI
                        .Arguments = "/k"
                        .RedirectStandardInput = True
                        .RedirectStandardOutput = True
                        .RedirectStandardError = True
                        .UseShellExecute = False
                        .CreateNoWindow = True
                        .WorkingDirectory = Environ("windir")
                    End With
                    Try
                        ShellProcess = Process.Start(SI)
                        With ShellProcess
                            .BeginOutputReadLine()
                            .BeginErrorReadLine()
                            .WaitForExit()
                        End With
                    Catch ex As Exception
                        With ex
                            Trace.WriteLine(.Message)
                            Trace.WriteLine(.Source)
                            Trace.WriteLine(.StackTrace)
                        End With
                    End Try
                Catch ex As Exception
                    With ex
                        Trace.WriteLine(.Message)
                        Trace.WriteLine(.Source)
                        Trace.WriteLine(.StackTrace)
                    End With
                End Try
            End Sub
    
            Private Sub ShellProcess_ErrorDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles ShellProcess.ErrorDataReceived
                If Not e.Data Is Nothing Then RaiseEvent DataReceived(Me, New CmdShellDataReceivedEventArgs(e.Data))
            End Sub
    
            Private Sub ShellProcess_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles ShellProcess.OutputDataReceived
                If Not e.Data Is Nothing Then RaiseEvent DataReceived(Me, New CmdShellDataReceivedEventArgs(e.Data & Environment.NewLine))
            End Sub
    
    #End Region
    
        End Class
    
        <EditorBrowsable(EditorBrowsableState.Never)> _
           Public Class CmdShellDataReceivedEventArgs : Inherits EventArgs
            Private _Value As String
    
            Public Sub New(ByVal value As String)
                _Value = value
            End Sub
    
            Public ReadOnly Property Value() As String
                Get
                    Return _Value
                End Get
            End Property
    
        End Class
    
    End Namespace
