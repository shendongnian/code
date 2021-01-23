    #Region " Option Statements "
    
    Option Strict On
    Option Explicit On
    Option Infer Off
    
    #End Region
    
    #Region " Imports "
    
    Imports Microsoft.VisualBasic.ApplicationServices
    Imports System.IO
    Imports System.Text
    
    #End Region
    
    Namespace My
    
        ''' <summary>
        ''' Class MyApplication.
        ''' </summary>
        Partial Friend Class MyApplication
    
    #Region " Properties "
    
            ''' <summary>
            ''' Gets the application path to pass the filepaths as a single-line argument.
            ''' </summary>
            ''' <value>The application path.</value>
            Private ReadOnly Property AppPath As String
                Get
                    Return Path.Combine(My.Application.Info.DirectoryPath, "MP3GainGUI.exe")
                End Get
            End Property
    
            ''' <summary>
            ''' Gets the inactivity timeout, in milliseconds.
            ''' </summary>
            ''' <value>The inactivity timeout, in milliseconds.</value>
            Private ReadOnly Property TimeOut As Integer
                Get
                    Return 750
                End Get
            End Property
    
            ''' <summary>
            ''' Gets the catched filepaths.
            ''' </summary>
            ''' <value>The catched filepaths.</value>
            Private ReadOnly Property FilePaths As String
                Get
                    Return Me.filePathsSB.ToString
                End Get
            End Property
    
    #End Region
    
    #Region " Misc. Objects "
    
            ''' <summary>
            ''' Stores the catched filepaths.
            ''' </summary>
            Private filePathsSB As StringBuilder
    
            ''' <summary>
            ''' Keeps track of the current filepath count.
            ''' </summary>
            Private filePathCount As Integer
    
            ''' <summary>
            ''' Timer that determines whether the app is inactive.
            ''' </summary>
            Private WithEvents inactivityTimer As New Timer With
                {
                    .Enabled = False,
                    .Interval = Me.TimeOut
                }
    
    #End Region
    
    #Region " Event Handlers "
    
            ''' <summary>
            ''' Handles the Startup event of the application.
            ''' </summary>
            ''' <param name="sender">The source of the event.</param>
            ''' <param name="e">The <see cref="ApplicationServices.StartupEventArgs"/> instance containing the event data.</param>
            Private Sub Me_Startup(ByVal sender As Object, ByVal e As StartupEventArgs) _
            Handles Me.Startup
    
                Select Case e.CommandLine.Count
    
                    Case 0 ' Terminate the application.
                        e.Cancel = True
    
                    Case Else ' Add the filepath argument and keep listen to next possible arguments.
                        Me.filePathsSB = New StringBuilder
                        Me.filePathsSB.AppendFormat("""{0}"" ", e.CommandLine.Item(0))
                        Me.filePathCount += 1
    
                        With Me.inactivityTimer
                            .Tag = Me.filePathCount
                            .Enabled = True
                            .Start()
                        End With
    
                End Select
    
            End Sub
    
            ''' <summary>
            ''' Handles the StartupNextInstance event of the application.
            ''' </summary>
            ''' <param name="sender">The source of the event.</param>
            ''' <param name="e">The <see cref="ApplicationServices.StartupNextInstanceEventArgs"/> instance containing the event data.</param>
            Private Sub Me_StartupNextInstance(ByVal sender As Object, ByVal e As StartupNextInstanceEventArgs) _
            Handles Me.StartupNextInstance
    
                Select Case e.CommandLine.Count
    
                    Case 0 ' Terminate the timer and run the application.
                        Me.TerminateTimer()
    
                    Case Else ' Add the filepath argument and keep listen to next possible arguments.
                        Me.filePathsSB.AppendFormat("""{0}"" ", e.CommandLine.Item(0))
                        Me.filePathCount += 1
    
                End Select
    
            End Sub
    
            ''' <summary>
            ''' Handles the Tick event of the InactivityTimer control.
            ''' </summary>
            ''' <param name="sender">The source of the event.</param>
            ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            Private Sub InactivityTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles inactivityTimer.Tick
    
                Dim tmr As Timer = DirectCast(sender, Timer)
    
                If DirectCast(tmr.Tag, Integer) = Me.filePathCount Then
                    Me.TerminateTimer()
    
                Else
                    tmr.Tag = Me.filePathCount
    
                End If
    
            End Sub
    
    #End Region
    
    #Region " Methods "
    
            ''' <summary>
            ''' Terminates the inactivity timer and runs the application.
            ''' </summary>
            Private Sub TerminateTimer()
    
                Me.inactivityTimer.Enabled = False
                Me.inactivityTimer.Stop()
                Me.RunApplication()
    
            End Sub
    
            ''' <summary>
            ''' Runs the default application passing all the filepaths as a single-line argument.
            ''' </summary>
            Private Sub RunApplication()
    
    #If DEBUG Then
                Debug.WriteLine(Me.FilePaths)
    #End If
                Try
                    Process.Start(Me.AppPath, Me.FilePaths)
    
                Catch ex As FileNotFoundException
                    ' Do Something?
                End Try
    
                ' Terminate the application.
                MyBase.MainForm.Close()
    
            End Sub
    
    #End Region
    
        End Class
    
    End Namespace
