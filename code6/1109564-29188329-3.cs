    Imports System.CodeDom.Compiler
    Imports System.IO
    Imports System.Reflection
    
    Public Class Form1
    Private Sub Test() Handles MyBase.Shown
        ' Create the ResX file.
        Dim resX As New ResXManager(Path.Combine(Application.StartupPath, "C:\MyResources.resx"))
        With resX
            .Create(replace:=True)
            .AddResource(Of String)("String Resource", "Hello World!", "String Comment")
        End With
        ' Compile an assembly.dll that contains the ResX file as an embedded resource.
        Dim codeProvider As CodeDomProvider = CodeDomProvider.CreateProvider("VB") ' or New VBCodeProvider()
        Dim parameters As CompilerParameters = New CompilerParameters()
        With parameters
            .GenerateExecutable = False
            .OutputAssembly = "C:\Assembly.dll"
            .EmbeddedResources.Add("C:\MyResources.resx")
        End With
        Dim results As CompilerResults = codeProvider.CompileAssemblyFromSource(parameters, "Public class ResourceClass : End Class")
        ' Read the assembly.
        Dim assembly As Assembly = assembly.LoadFile("c:\Assembly.dll")
        ' Extract/read the ResX file from assembly.
        Dim embeddedFileName As String = "MyResources.resx"
        Dim targetFilePath As String = "C:\NewMyResources.resx"
        Using s As Stream = assembly.GetManifestResourceStream(embeddedFileName)
            Dim buffer As Byte() = New Byte(CInt(s.Length - 1)) {}
            Dim read As Integer = s.Read(buffer, 0, CInt(s.Length))
            Using fs As New FileStream(targetFilePath, FileMode.Create)
                fs.Write(buffer, 0, buffer.Length)
            End Using
        End Using
    End Sub
    End Class
