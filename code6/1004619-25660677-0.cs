    Namespace Tokens
    Public Class GeneratedArticleId
        Inherits ExpandInitialFieldValueProcessor
        Public Overrides Sub Process(ByVal args As ExpandInitialFieldValueArgs)
            If args.SourceField.Value.Contains("$articleid") Then
                Dim database = Sitecore.Client.ContentDatabase
                Dim counter = database.GetItem(New ID("Our Item"))
                If counter Is Nothing Then
                    args.Result = ""
                    Exit Sub
                End If
                Dim idfield = AppendToIdValue(counter("ID"))
                Using New SecurityDisabler()
                    counter.Editing.BeginEdit()
                    counter.Fields("ID").Value = idfield
                    counter.Editing.EndEdit()
                End Using
                If args.TargetItem IsNot Nothing Then
                    args.Result = args.Result.Replace("$articleid", idfield)
                End If
            End If
        End Sub
        'Extracts the digits and adds one
        Private Shared Function AppendToIdValue(ByVal id As String)
            Dim letterprefix = Left(id, 2)
            Dim integervalue = CInt(id.Replace(letterprefix, ""))
            integervalue += 1
            Return letterprefix & integervalue.ToString("000000")
        End Function
    End Class
    End Namespace
