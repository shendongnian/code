        Public Function SerializeWords(ByRef oWords As List(Of Word))
            Dim sb As New StringBuilder
            Dim sw As New IO.StringWriter(sb)
            Using oWriter As Newtonsoft.Json.JsonWriter = New Newtonsoft.Json.JsonTextWriter(sw)
                With oWriter
                    .WriteStartArray()
                    For Each oWord As Word In oWords
                        .WriteStartObject()
                        .WritePropertyName("ID")
                        .WriteValue(oWord.ID)
                        .WritePropertyName("Phonics")
                        .WriteValue(oWord.Phonics)
                        .WritePropertyName("Word_")
                        .WriteValue(oWord.Word_)
                        .WritePropertyName("WordLength")
                        .WriteValue(oWord.WordLength)
                        .WriteEndObject()
                    Next
                    .WriteEndArray()
                End With
            End Using
            Return sb.ToString
        End Function
