    Imports System.IO
    Imports System.Net
    
    Module Module1
    
        Sub Main()
            Dim sw As New Stopwatch
            sw.Start()
    
            Try
                Dim args = Environment.GetCommandLineArgs.ToList
                If args.Count = 1 Then Throw New Exception("WebsiteWaitResponse url [user] [password]")
    
                Console.WriteLine("{0:c} WebsiteWaitResponse {1:g}", sw.Elapsed, Now())
    
                Dim web As New WebClient
                If args.Count > 2 Then web.Credentials = New NetworkCredential(args(2), args(3))
                Dim results = web.DownloadString(args(1))
                Console.WriteLine(results)
    
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
    
            Console.WriteLine("{0:c} WebsiteWaitResponse Complete", sw.Elapsed)
            End
        End Sub
    
    End Module
