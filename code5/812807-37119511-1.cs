    class Program
        {
            static void Main(string[] args)
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                string sql = null;
    
                connetionString = "Data Source=Server Name;Initial Catalog=DataBaseName;User ID=UserID;Password=Password";
                sql = "INSERT INTO LoanRequest(idLoanRequest,RequestDate,Pickupdate,ReturnDate,EventDescription,LocationOfEvent,ApprovalComments,Quantity,Approved,EquipmentAvailable,ModifyRequest,Equipment,Requester)VALUES('5','2016-1-1','2016-2-2','2016-3-3','DescP','Loca1','Appcoment','2','true','true','true','4','5')";
                connection = new SqlConnection(connetionString);
    
                try
                {
                    connection.Open();
                    Console.WriteLine(" Connection Opened ");
                    command = new SqlCommand(sql, connection);                
                    SqlDataReader dr1 = command.ExecuteReader();         
                    
                    connection.Close();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
    		
    	}
