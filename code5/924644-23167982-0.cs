    string constr = Properties.Settings.Default.Subject_1ConnectionString;
    
    // if you only need one single data table - use a DataTable - not a DataSet !
    DataTable dt = new DataTable();
    
    // *ALWAYS* put your SqlConnection and SqlCommand into using() blocks!
    // also - if you want to use BETWEEN, you *MUST* use DATE!
    // also: don't call your column "date" - that's a SQL Server reserved keyword! Use a more meaningful name 
    // like "DateCreated" or "DateLastUpdated" or something
    // and please also use more meaningful parameter names - "hello" and "hello1" is very confusing and not clear!!
    using (SqlConnection conn = new SqlConnection(constr))
    using (SqlCommand com = new SqlCommand("SELECT * FROM dbo.Subject_Title WHERE CAST(DateCreated AS DATE) BETWEEN @start and @end ", conn))
    {
       // add parameters as DATE type!
       com.Parameters.Add("@start", SqlDbType.Date);
       com.Parameters["@start"].Value = Date.Parse(textBox1.Text);
    
       com.Parameters.Add("@end", SqlDbType.Date);
       com.Parameters["@end"].Value = Date.Parse(textBox2.Text);
    
       SqlDataAdapter da = new SqlDataAdapter(com);
       
       da.Fill(dt, "Subject_title");
    }
    
    for (int i = 0; i < 8; i++)
    {
        this.labeltext = this.labeltext + " " + dt.Rows[i]["Date"].ToString();
        this.labeltext = this.labeltext + " " + ds.Rows[i]["Subject"].ToString();
        this.labeltext = this.labeltext + " ";
    }
    
    this.label1.Text = this.labeltext;
