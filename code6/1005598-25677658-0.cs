    DataTable tblCustomerInfo = YourQueryToGetCustomerData( customerID );
    DataTable tblContactNumbers = YourQueryToGetContacts( customerID );
    DataTable tblBankAcnts = YourQueryToGetContacts( customerID );
    
    tblCustomerInfo.TableName = "CustInfo";
    tblContactNumbers.TableName = "Contacts";
    tblBankAcnts.TableName = "BankAcnts";
    
    DataSet dsAllTables = new DataSet();
    dsAllTables.Add( tblCustomerInfo );
    dsAllTables.Add( tblContactNumbers );
    dsAllTables.Add( BankAcnts );
    
    
    // Then, you can write out the XSD for the report for named references to the table/columns
    dsAllTables.WriteXmlSchema( "YourReport.xsd");
    dsAllTables.WriteXml( "YourReport.xml");
