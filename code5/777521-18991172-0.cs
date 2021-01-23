    public string connectionStringWFFM = "user id=sitecore_admin;password=xxx;Data Source=SitecoreDBServer.com;Database=Sitecore_WebForms";
    
    protected DataTable BuildDataTable(Item formItem)
    {
    	List<FormResult> formResults = FormResults(formItem.ID.Guid);
    	List<Field> distinctFields = DistinctFields(formItem.ID.Guid);
    
    	var dt = new DataTable();
    	dt.Columns.Add("Submission_DateTime", typeof (string));
    	foreach (Field field in distinctFields)
    	{
    		var dataColumn = new DataColumn("_" + field.id.ToString("N"), typeof (string));
    		dataColumn.Caption = field.name.Replace(" ", "_");
    		dt.Columns.Add(dataColumn);
    	}
    
    	foreach (FormResult formResult in formResults)
    	{
    		var connection = new SqlConnection();
    		connection.ConnectionString = connectionStringWFFM;
    		var command = new SqlCommand();
    		command.Connection = connection;
    		command.CommandText = "select fieldid, value from field where formid=@formid order by fieldid";
    		command.Parameters.Add("@formid", SqlDbType.UniqueIdentifier).Value = formResult.id;
    		connection.Open();
    		SqlDataReader reader = command.ExecuteReader();
    
    		DataRow dataRow = dt.NewRow();
    		dataRow["Submission_DateTime"] = formResult.timestamp.ToString("MM/dd/yyyy HH:mm:ss");
    		while (reader.Read())
    		{
    			dataRow["_" + reader.GetGuid(0).ToString("N")] = reader.GetValue(1).ToString().Replace("<item>", "").Replace("</item>", "");
    		}
    		dt.Rows.Add(dataRow);
    
    		reader.Close();
    		connection.Close();
    	}
    
    	return dt;
    }
    
    public List<Field> DistinctFields(Guid formitemid)
    {
    	var connection = new SqlConnection();
    	connection.ConnectionString = connectionStringWFFM;
    	var command = new SqlCommand();
    	command.Connection = connection;
    	command.CommandText = "select distinct fieldid from field where formid in (select id from form where formitemid=@formitemid) order by fieldid";
    	command.Parameters.Add("@formitemid", SqlDbType.UniqueIdentifier).Value = formitemid;
    	connection.Open();
    	SqlDataReader reader = command.ExecuteReader();
    
    	var results = new List<Field>();
    	int count = 0;
    	while (reader.Read())
    	{
    		var field = new Field();
    		field.id = reader.GetGuid(0);
    		Database database = Factory.GetDatabase("master");
    		Item i = database.GetItem(new ID(field.id));
    		if (i != null && i.DisplayName != null)
    		{
    			field.name = i.DisplayName;
    		}
    		else
    		{
    			field.name = "Field" + count;
    		}
    		results.Add(field);
    		count += 1;
    	}
    
    	reader.Close();
    	connection.Close();
    
    	return results;
    }
    
    public List<FormResult> FormResults(Guid formitemid)
    {
    	var connection = new SqlConnection();
    	connection.ConnectionString = connectionStringWFFM;
    	var command = new SqlCommand();
    	command.Connection = connection;
    	command.CommandText = "select id, timestamp from form where formitemid=@formitemid";
    	command.Parameters.Add("@formitemid", SqlDbType.UniqueIdentifier).Value = formitemid;
    	connection.Open();
    	SqlDataReader reader = command.ExecuteReader();
    
    	var results = new List<FormResult>();
    
    	while (reader.Read())
    	{
    		var result = new FormResult();
    		result.id = reader.GetGuid(0);
    		result.timestamp = reader.GetDateTime(1);
    		results.Add(result);
    	}
    
    	reader.Close();
    	connection.Close();
    
    	return results;
    }
    
    public class FormResult
    {
    	public Guid id { get; set; }
    	public DateTime timestamp { get; set; }
    }
    
    public class Field
    {
    	public Guid id { get; set; }
    	public string name { get; set; }
    }
