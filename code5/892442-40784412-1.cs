    Imports System.IO
    Imports System.Text
    Imports System.Xml
    Imports System.Xml.Serialization
    
    Friend Module XML
    
        Public Function Deserialize(Of T)(ByVal filename As String) As T
    
            Dim result As T
    
            Using reader As New StreamReader(filename, True)
    
                Dim serializer As New XmlSerializer(GetType(T))
                result = CType(serializer.Deserialize(XmlReader.Create(reader)), T)
    
            End Using
    
            Return result
    
        End Function
    
        Public Sub Serialize(Of T)(ByVal filename As String, ByVal obj As T, ByVal qualifiedNames As XmlQualifiedName(), ByVal encoding As Encoding)
    
            Dim namespaces As New XmlSerializerNamespaces(qualifiedNames)
            Dim settings = New System.Xml.XmlWriterSettings()
            settings.Encoding = encoding
    
            Dim serializer = New XmlSerializer(GetType(T))
    
            Using writer = XmlWriter.Create(filename, settings)
    
                writer.WriteStartDocument(True)
                serializer.Serialize(writer, obj, namespaces)
    
            End Using
    
        End Sub
    
    End Module
