    var result = JsonConvert.DeserializeObject<Result>(jsonStr);
---
    public class Customer
	{
		public string Account_Number { get; set; }
		public object Account_Payment_Status { get; set; }
		public object Account_Status { get; set; }
		public object Create_Date { get; set; }
		public int Customer_ID { get; set; }
		public object Email { get; set; }
		public string First_Name { get; set; }
		public object Last4SSN { get; set; }
		public object LastPayment_Amount { get; set; }
		public string Last_Name { get; set; }
		public object Last_Payment_Date { get; set; }
		public object Modified_Date { get; set; }
		public bool Online_Agreement { get; set; }
		public object Payment_in { get; set; }
		public object Username { get; set; }
		public bool isActivated { get; set; }
		public bool isActive { get; set; }
		public bool isLocked { get; set; }
		public bool isRegistered { get; set; }
		public int unsuccessful_login_count { get; set; }
	}
	public class Result
	{
		public List<Customer> GetAllCustomersResult { get; set; }
	}
