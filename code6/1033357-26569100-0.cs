    // the class that represents the result you want
    public class MaxId
    {
        public int id { get; set; }
    }
----------
    // now you need to cast it to an "id" as well....
    var idMensaje = dbConn.Query<MaxId>("select MAX(id) AS id from MensajeTablon");
