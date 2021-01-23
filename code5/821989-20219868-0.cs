    var customerQuery = context.CustomerTable.Select( ct => 
        new { 
            ct.ID, 
            ct.CustomerTitle, 
            // use nav property to get customer payments
            CustomerPayments = ct.CustomerPayments.Select( cp => 
                new { 
                    Range = cp.Range, 
                    Values = cp.Values } ) } );
    return customerQuery.ToArray()
        .Select( cq => 
            {
                var retVal = new SCustomerInfo( CreateCustomerTable(), cq.ID, cq.CustomerTitle ); 
                foreach( var customerPayment in cq.CustomerPayments )
                {
                    var dtRow = cq.PaymentTable.NewRow();
                    dtRow.ItemArray = new object[] { customerPayment.Range, customerPayment.Values };
                    retVal.PaymentTable.Rows.Add( dtRow );
                }
                return retVal;
            } );
