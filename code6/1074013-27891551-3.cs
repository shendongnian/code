    Imports System.Reflection
    Imports System.Globalization
    Imports System.IO
    
    Class Application
    
        ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
        ' can be handled in this file.
        Private Shared Function ResolveAssembly(sender As Object, args As ResolveEventArgs) As Assembly
            Try
                Dim parentAssembly As Assembly = Assembly.GetExecutingAssembly()
    
                Dim name = args.Name.Substring(0, args.Name.IndexOf(","c)) + ".dll"
                Dim resourceName = parentAssembly.GetManifestResourceNames().First(Function(s) s.EndsWith(name))
    
                Using stream As Stream = parentAssembly.GetManifestResourceStream(resourceName)
                    Dim block As Byte() = New Byte(stream.Length - 1) {}
                    stream.Read(block, 0, block.Length)
                    Return Assembly.Load(block)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & ex.InnerException.ToString)
                Return Nothing
            End Try
        End Function
        Public Sub New()
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ResolveAssembly
        End Sub
    End Class
