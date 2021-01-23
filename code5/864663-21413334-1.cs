    ''' <summary>
    ''' The CLI Class where are defined the CLI methods and other CLI things.
    ''' </summary>
    Module CLI
    
        ''' <summary>
        ''' Defines the entry point of the application.
        ''' </summary>
        Public Sub Main()
    
            If My.Application.CommandLineArgs.Count <> 0 Then
    
                ' Attach the console.
                NativeMethods.AttachConsole(-1)
    
                ' Call the method that parses the CLI arguments (if any),
                ' this is done before loading the GUI form to speed up the CLI startup.
                ParseCLIArguments()
    
            Else
    
                ' Any argument was passed so I show the GUI form.
                GUI.ShowDialog()
    
            End If
    
        End Sub
    ''' <summary>
    ''' Parses the Command-Line arguments.
    ''' </summary>
    Private sub ParseCLIArguments
        ...
    End Sub
    End Module
