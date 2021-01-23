    <SqlFunction()> _
    Public Shared Function ResetSchema(ByVal targetNameSpace As SqlString, ByVal schemaUri As SqlString) As Boolean
        Dim result As Boolean
        Try
            schemaSet = New XmlSchemaSet
            schemaSet.Add(targetNameSpace, schemaUri)
            schemaSet.Compile()
            settings = New XmlReaderSettings
            settings.Schemas = schemaSet
            settings.ValidationType = ValidationType.Schema
            settings.ConformanceLevel = ConformanceLevel.Auto
            settings.ValidationFlags = settings.ValidationFlags Or XmlSchemaValidationFlags.ReportValidationWarnings
            AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
            result = True
        Catch
            'result = False
        End Try
        ResetSchema = result
    End Function
    Public Shared Function ValidateWithXsd(ByVal xml As SqlXml) As SqlBoolean
        Try
            isValid = True
            Dim reader As XmlReader = xml.CreateReader
            Dim validatingReader As XmlReader = XmlReader.Create(reader, settings)
            While validatingReader.Read
            End While
        Catch ex As Exception
            Throw ex
        Finally
            ValidateWithXsd = isValid
        End Try
    End Function
    Private Shared Sub ValidationCallBack(ByVal sender As Object, ByVal args As ValidationEventArgs)
        isValid = False
    End Sub
