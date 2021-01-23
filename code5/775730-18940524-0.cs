     Public Class Offer
    
            Public OfferID As Integer
            Public PropertyID As Integer
            Public AgentUserID As Integer
            Public AgentName As String
            Public BuyerUserID As Integer
            Public BuyerName As String
            Public BuyerType As String
            Public Offer As Integer
            Public NetOffer As Integer
            Public ClosingCost As Integer
            Public Allowances As Integer
            Public RepairCosts As Integer
            Public TotalCredits As Integer
            Public OfferType As String
            Public OfferDate As String
            Public ProxyOffer As Integer
            Public NetProxyOffer As Integer
            Public ResultResponse As SUBMIT_OFFER_RESULT
            'Public ResultAcceptedOffer As Integer
            Public ResultAcceptedNetOffer As Integer
            'Public ResultHighestOffer As Integer
            Public ResultHighestNetOffer As Integer
            Public Notifications As ArrayList = New ArrayList
            Public EarnestMoneyDeposit As Integer
            Public DownPayment As Integer
            Public TypeOfFinancing As String
            Public OfferStatus As String
            Public Note As String
            Public Visble As Boolean = True
            Public OfferStatusChangedDate As DateTime
            Public EstimatedCloseDate As DateTime
            Public SourceType As String
    
            Public Sub GetOffer(ByVal offerID As Integer)
    
                Dim offerDB As OSP.DataAccess.OfferDB = New OSP.DataAccess.OfferDB
                Dim rs As SqlClient.SqlDataReader
                rs = offerDB.GetOffer(offerID)
                Do While rs.Read
                    Me.OfferID = offerID
                    Me.PropertyID = rs("PROPERTY_ID")
                    Me.AgentUserID = rs("AGENT_USER_ID")
                    Me.BuyerUserID = IIf(IsDBNull(rs("BUYER_USER_ID")), 0, rs("BUYER_USER_ID"))
                    Me.Offer = rs("OFFER")
                    Me.NetOffer = rs("NET_OFFER")
                    Me.TotalCredits = rs("TOTAL_CREDITS")
                    Me.ProxyOffer = rs("PROXY_OFFER")
                    Me.OfferType = rs("OFFERTYPE")
                    Me.OfferDate = rs("OFFER_DATE")
                    Me.DownPayment = IIf(IsDBNull(rs("DOWN_PAYMENT")), 0, rs("DOWN_PAYMENT"))
                    Me.EarnestMoneyDeposit = IIf(IsDBNull(rs("EARNEST_MONEY_DEPOSIT")), 0, rs("EARNEST_MONEY_DEPOSIT"))
                    Me.TypeOfFinancing = rs("TYPE_OF_FINANCING")
                    Me.BuyerName = GlobalFunctions.DefaultString(rs("BUYER_NAME"))
                    Me.BuyerType = GlobalFunctions.DefaultString(rs("BUYER_TYPE"))
                    Me.AgentName = rs("OFFER_BY_NAME")
                    Me.OfferStatus = GlobalFunctions.DefaultString(rs("OFFER_STATUS"))
                    Me.Note = GlobalFunctions.DefaultString(rs("NOTE"))
                    Me.OfferStatusChangedDate = IIf(IsDBNull(rs("OFFER_STATUS_CHANGED_DATE")), Me.OfferStatusChangedDate, rs("OFFER_STATUS_CHANGED_DATE"))
                    Me.Visble = IIf(IsDBNull(rs("VISIBLE")), True, rs("VISIBLE"))
                    Me.EstimatedCloseDate = IIf(IsDBNull(rs("ESTIMATED_CLOSE_DATE")), DateTime.MinValue, rs("ESTIMATED_CLOSE_DATE"))
                Loop
    
                Try
                    If Not rs.IsClosed Then
                        rs.Close() : rs = Nothing
                    End If
                    If Not offerDB Is Nothing Then
                        offerDB.Dispose() : offerDB = Nothing
                    End If
                Catch : End Try
    
            End Sub
    
            Public Function UpdateOffer() As Integer
    
                Dim offerDB As OSP.DataAccess.OfferDB = New OSP.DataAccess.OfferDB
                Return offerDB.UpdateOffer(Me)
    
            End Function
    End Class
    
     Public Class OfferDB
            Implements System.IDisposable
    
    
            Dim db As SQLDatabase
    
            Public Sub New()
                db = New SQLDatabase(GlobalSettings.GetDefaultConnectionString)
            End Sub
    
            Public Sub Dispose() Implements System.IDisposable.Dispose
    
                If Not db Is Nothing Then
                    db = Nothing
                End If
    
            End Sub
    
      Public Function GetOffer(ByVal offerID As Integer) As SqlClient.SqlDataReader
    
                Dim dbCommand As DbCommand = db.GetStoredProcCommand("OSP_GET_OFFER")
                db.AddInParameter(dbCommand, "@OFFER_ID", SqlDbType.Int, offerID)
    
                Try
                    Return db.ExecuteReader(dbCommand)
                Catch ex As Exception
                    Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "EXCEPTION_CRITICAL")
                    If (rethrow) Then
                        Throw
                    End If
                End Try
    
    
            End Function
    
    
            Public Function UpdateOffer(ByVal offer As OSP.Offer) As Integer
    
                Dim dbCommand As DbCommand = db.GetStoredProcCommand("OSP_UPDATE_OFFER")
    
                db.AddInParameter(dbCommand, "@OFFER_ID", SqlDbType.Int, offer.OfferID)
                db.AddInParameter(dbCommand, "@BUYER_USER_ID", SqlDbType.Int, offer.BuyerUserID)
                db.AddInParameter(dbCommand, "@OFFER", SqlDbType.Int, offer.Offer)
                db.AddInParameter(dbCommand, "@TOTAL_CREDITS", SqlDbType.Int, offer.TotalCredits)
                db.AddInParameter(dbCommand, "@OFFER_TYPE", SqlDbType.VarChar, offer.OfferType)
                db.AddInParameter(dbCommand, "@OFFER_DATE", SqlDbType.VarChar, offer.OfferDate)
                db.AddInParameter(dbCommand, "@TYPE_OF_FINANCING", SqlDbType.VarChar, offer.TypeOfFinancing)
                db.AddInParameter(dbCommand, "@DOWN_PAYMENT", SqlDbType.Int, offer.DownPayment)
                db.AddInParameter(dbCommand, "@EARNEST_MONEY_DEPOSIT", SqlDbType.Int, offer.EarnestMoneyDeposit)
                db.AddInParameter(dbCommand, "@OFFER_STATUS", SqlDbType.VarChar, offer.OfferStatus)
                db.AddInParameter(dbCommand, "@NOTE", SqlDbType.VarChar, offer.Note)
                If Not offer.OfferStatusChangedDate = DateTime.MinValue Then
                    db.AddInParameter(dbCommand, "@OFFER_STATUS_CHANGED_DATE", SqlDbType.DateTime, offer.OfferStatusChangedDate)
                End If
    
                Try
                    Return db.ExecuteScalar(dbCommand)
                Catch ex As Exception
                    Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "EXCEPTION_CRITICAL")
                    If (rethrow) Then
                        Throw
                    End If
                End Try
    
            End Function
    End Class
