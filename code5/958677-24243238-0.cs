    Imports Microsoft.Exchange.WebServices.Data
        Public Class Exchange
                
                 Public Sub SendEmail(fromEmailAddress As String, toEmailAddress As String, body As String, subject As String)
               
             Dim exService = New ExchangeService(serverVersion)
                exService.AutodiscoverUrl(fromEmailAddress)
                
                
                Dim msg As New EmailMessage(exService)
                msg.Subject = subject
                
                msg.Body = body
            
             msg.ToRecipients.Add(New Microsoft.Exchange.WebServices.Data.EmailAddress(toEmailAddress,toEmailAddress))
                
                msg.SendAndSaveCopy()
        
        End Sub
    End Class
