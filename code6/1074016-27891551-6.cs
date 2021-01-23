    ''' <summary>
    ''' Tells the program that the Assembly it's Seeking is located in the Embedded resources By using the
    ''' <see cref="Assembly.GetManifestResourceNames"/> Function To get All the Resources
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <returns></returns>
    ''' <remarks>Note that this event won't fire if the dll is in the same folder as the application (sometimes)</remarks>
    Private Shared Function OnResolveAssembly(sender As Object, args As ResolveEventArgs) As Assembly
        Try
            'gets the main Assembly
            Dim parentAssembly = Assembly.GetExecutingAssembly()
            'args.Name will be something like this
            '[ MahApps.Metro, Version=1.1.3.81, Culture=en-US, PublicKeyToken=null ]
            'so we take the name of the Assembly (MahApps.Metro) then add (.dll) to it
            Dim finalname = args.Name.Substring(0, args.Name.IndexOf(","c)) & ".dll"
            'here we search the resources for our dll and get the first match
            Dim ResourcesList = parentAssembly.GetManifestResourceNames()
            Dim OurResourceName As String = Nothing
            '(you can replace this with a LINQ extension like [Find] or [First])
            For i As Integer = 0 To ResourcesList.Count - 1
                Dim name = ResourcesList(i)
                If name.EndsWith(finalname) Then
                    'Get the name then close the loop to get the first occuring value
                    OurResourceName = name
                    Exit For
                End If
            Next
            If Not String.IsNullOrWhiteSpace(OurResourceName) Then
                'get a stream representing our resource then load it as bytes
                Using stream As Stream = parentAssembly.GetManifestResourceStream(OurResourceName)
                    'in vb.net use [ New Byte(stream.Length - 1) ]
                    'in c#.net use [ new byte[stream.Length]; ]
                    Dim block As Byte() = New Byte(stream.Length - 1) {}
                    stream.Read(block, 0, block.Length)
                    Return Assembly.Load(block)
                End Using
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
