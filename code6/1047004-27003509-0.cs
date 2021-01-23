    'Using Keyword Partial not necessary anymore,  
    'because it is used in the `yourForm.Designer.vb` 
    Public Class yourForm
        Public Sub Changelabel()
            If getLanguage() = "en" Then 
                label1.text = "Good Morning" 
            Else 
                label1.Text = "Bonjour"
            End If
        End Sub
    End Class
