    ''' <summary>
    ''' Determines whether an exe or dll file is an .Net assembly.
    ''' </summary>
    ''' <param name="File">Indicates the exe/dll file to check.</param>
    ''' <returns><c>true</c> if file is an .Net assembly, <c>false</c> otherwise.</returns>
    Friend Function FileIsNetAssembly(ByVal [File] As String) As Boolean
        Try
            System.Reflection.AssemblyName.GetAssemblyName([File])
            ' The file is an Assembly.
            Return True
        Catch exFLE As IO.FileLoadException
            ' The file is an Assembly but has already been loaded.
            Return True
        Catch exBIFE As BadImageFormatException
            ' The file is not an Assembly.
            Return False
        End Try
    End Function
