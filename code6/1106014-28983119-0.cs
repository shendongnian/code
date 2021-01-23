    //set the service to receive one call at a time
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        StringBuilder sb = new StringBuilder();
        private SqlConnection con = new SqlConnection(
            @"Data Source=YOAV-DEV\SQLEXPRESS2012;
            Initial Catalog=Test;Integrated Security=True");
        private string query = @"DECLARE @val int;
    SET @val =(select top(1) VALUE from SerialNumber where Used = 0);
    UPDATE SerialNumber SET Used = 1 WHERE Value = @val;
    UPDATE WorkOrder SET NextSerial = (@val +1);
    SELECT @val;";
        public string GetData()
        {
            //dapper dot net query
            var res = con.Query<int>(query).Single(); 
            return res.ToString();
        }
    }
