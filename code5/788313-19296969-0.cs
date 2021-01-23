	Imports System.Runtime.Serialization
	Imports System.Xml
	Imports System.IO
	Imports System.Text
    Namespace NamespaceGoesHere
		<DataContract()> _
		Public Class ClassNameGoesHere
			'All your properties go here, for example:
			<DataMember> Property PropertyName As String = "test"
			'Note the use of <DataMember> and <DataContract()>
		
			#Region "Serialisation"
				Public Function Serialise() As String
					Dim s As New System.IO.MemoryStream
					Dim x As New DataContractSerializer(GetType(ClassNameGoesHere))
					x.WriteObject(s, Me)
					s.Position = 0
					Dim sw As New StreamReader(s)
					Dim str As String
					str = sw.ReadToEnd()
					Return str
				End Function
				Public Shared Function DeSerialise(xmlDocument As String) As ClassNameGoesHere
					Dim doc As New XmlDocument
					Dim ser As New DataContractSerializer(GetType(ClassNameGoesHere))
					Dim stringWriter As New StringWriter()
					Dim xmlWriter As New XmlTextWriter(stringWriter)
					doc.LoadXml(xmlDocument)
					doc.WriteTo(xmlWriter)
					Dim stream As New MemoryStream(Encoding.UTF8.GetBytes(stringWriter.ToString()))
					stream.Position = 0
					Dim reader As XmlDictionaryReader = XmlDictionaryReader.CreateTextReader(stream, New XmlDictionaryReaderQuotas())
					Return DirectCast(ser.ReadObject(reader, True), ClassNameGoesHere)
				End Function
			#End Region
		End Class
	End Namespace
