	[DataContract]
	class Request
	{
		[DataMember]
		public string api_key { get; set; }
		[DataMember]
		public string account_id { get; set; }
		[DataMember]
		public List<Recipient> recipient { get; set; } //THIS is what I missed originally
	}
	
	[DataContract]
	class Recipient 
	{
		[DataMember(Name = "name_id")]
		public string nameID { get; set; } 
		[DataMember(Name = "first_name")]
		public string firstname { get ; set; } 
		[DataMember(Name = "last_name")]
		public string lastname { get; set; } 
		[DataMember(Name = "Unit_number")]
		public string unitNumber { get; set; } 
		[DataMember]
		public string email { get; set; } 
		[DataMember]
		public string cellphone { get; set; }
	}
	Request request = new Request();
	Recipient recipient = new Recipient();           
	//setup request object
	request.account_id = accountID;
	request.api_key = apiKey; 
	request.recipient = new List<Recipient>(); //Don't forget to do this or you'll have null reference when you add the recipient objects to the request list
	//setup connection to stored proc
	SqlConnection sqlCon = new SqlConnection("ConnectionStringHere");
	//Read data from stored proc
	using (SqlCommand sqlCmd = new SqlCommand("StoredProcedureNameHere", sqlCon))
	{
		//setup command type
		sqlCmd.CommandType = CommandType.StoredProcedure;
		//Open connection
		sqlCon.Open();
		//Execute the reader
		using (SqlDataReader sqlRd = sqlCmd.ExecuteReader())
		{
			//while we still have data keep going
			while (sqlRd.Read())
			{
				recipient.nameID = sqlRd["column1"].ToString();
				recipient.unitNumber = sqlRd["column2"].ToString().Trim(); //example of trimming out white space
				recipient.firstname = sqlRd["column3"].ToString();
				recipient.lastname = sqlRd["column4"].ToString();
				recipient.email = sqlRd["column5"].ToString();
				recipient.cellphone = Regex.Replace(sqlRd["column6"].ToString(), "[^.0-9]", ""); //example of setting the value to only numbers removing anything else
				//store recipient to request object
				request.recipient.Add(recipient); //This will put the items in the object for proper serialization based on the object structure
			}
		} 
		//finished close connection
		sqlCon.Close();
	}
	//serialize dataset into JSON request
	string jsonString = SerializeJSon<Request>(request); //Link to function for this code can be found in the original question
