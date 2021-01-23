    [ServiceContract]
    public interface IServiceClient
    {
        [OperationContract]
        void InsertMaster(Service ServiceObj);
    }
    [DataContract]
    public class Service
    {
        [DataMember]
        public string Id;
        [DataMember]
        public string Submitter;
        [DataMember]
        public string Comments;
        [DataMember]
        public DateTime TimeSubmitted;
    }
    public void InsertMaster(Service ServiceObj)
    {
        string query = "INSERT INTO movies (id, submitter, comments, time) VALUES(ServiceObj.id, ServiceObj.submitter, ServiceObj.comments, ServiceObj.time)";
        //open connection
        connection.Open();
        //create command and assign the query and connection from the constructor
        MySqlCommand cmd = new MySqlCommand(query, connection);
        //Execute command
        cmd.ExecuteNonQuery();
        //close connection
        connection.Close();
        
    }
