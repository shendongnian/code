    String queryString = "Select NRCode__c,Amazon_Listing_Level__c, Amazon_Rule_ID__c,ESTShipPrice__c from vendors";
    SqlDataAdapter sda = new SqlDataAdapter(queryString, connectionString);
    DataTable results = new DataTable();
    sda.Fill(results);
    GridView1.AutoGenerateColumns = true;
    GridView1.DataSource = results;
    GridView1.DataBind();
