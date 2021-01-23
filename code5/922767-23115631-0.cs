       If m_myVar
           For Each c In Page.Controls
                    If TypeOf c Is HtmlForm Then
                        Dim ctrl As New MyControl1
                        c.Controls.Add(ctrl)
                    End If
           Next
       End If
   
