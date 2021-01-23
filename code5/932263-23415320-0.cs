    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using eFContext As New ApplicationEntities()
            Dim requestedTransactionId As Guid = GetAndCheckQueryStringValueGuid("TransactionId")
            Dim requestedTransaction As Transaction = Transaction.GetAndConfirm(eFContext, requestedTransactionId)
            Dim requestedCustomers As IQueryable(Of Object) =
                Customer.GetCustomersForCustomersGrid(eFContext, requestedTransaction)
            CustomersGridView.DataSource = requestedCustomers
            CustomersGridView.DataBind()
    End Sub
