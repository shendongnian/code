    <connectionStrings>
       <add name="ApplicationServices" connectionString="copy connection string here" 
        />
     </connectionStrings>
----------
        
   
         SqlCommand command = new SqlCommand();
         command.CommandText = "SumofPowders";
         command.CommandType = CommandType.StoredProcedure;
         con.open();
         SqlDataAdapter da = new SqlDataAdapter(command,con);
         DataSet ds = new DataSet();
         da.Fill(ds);
         InsightPro_BarChart.DataSource = ds;
         InsightPro_BarChart.DataBind();
