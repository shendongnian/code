    Imports System.Web.Http
    Imports Amazon.SimpleNotificationService
    Namespace Controllers
        Public Class AmazonController
            Inherits ApiController
            <HttpPost>
            <Route("amazon/bounce-handler")>
            Public Function HandleBounce() As IHttpActionResult
                Try
                    Dim msg = Util.Message.ParseMessage(Request.Content.ReadAsStringAsync().Result)
                    If Not msg.IsMessageSignatureValid Then
                        Return BadRequest("Invalid Signature!")
                    End If
                    If msg.IsSubscriptionType Then
                        msg.SubscribeToTopic()
                        Return Ok("Subscribed!")
                    End If
                    If msg.IsNotificationType Then
                        Dim bmsg = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Message)(msg.MessageText)
                        If bmsg.notificationType = "Bounce" Then
                            Dim emails = (From e In bmsg.bounce.bouncedRecipients
                                          Select e.emailAddress).Distinct()
                            If bmsg.bounce.bounceType = "Permanent" Then
                                For Each e In emails
                                    'this email address is permanantly bounced. don't ever send any mails to this address. remove from list.
                                Next
                            Else
                                For Each e In emails
                                    'this email address is temporarily bounced. don't send any more emails to this for a while. mark in db as temp bounce.
                                Next
                            End If
                        End If
                    End If
                Catch ex As Exception
                    'log or notify of this error to admin for further investigation
                End Try
                Return Ok("done...")
            End Function
            Private Class BouncedRecipient
                Public Property emailAddress As String
                Public Property status As String
                Public Property diagnosticCode As String
                Public Property action As String
            End Class
            Private Class Bounce
                Public Property bounceSubType As String
                Public Property bounceType As String
                Public Property reportingMTA As String
                Public Property bouncedRecipients As BouncedRecipient()
                Public Property timestamp As DateTime
                Public Property feedbackId As String
            End Class
            Private Class Mail
                Public Property timestamp As DateTime
                Public Property source As String
                Public Property sendingAccountId As String
                Public Property messageId As String
                Public Property destination As String()
                Public Property sourceArn As String
            End Class
            Private Class Message
                Public Property notificationType As String
                Public Property bounce As Bounce
                Public Property mail As Mail
            End Class
        End Class
    End Namespace
