    <handlers>
        <add path="api*" name="ServiceStack.Factory" type="ServiceStack.WebHost.Endpoints.ServiceStackHttpHandlerFactory, ServiceStack" verb="*" preCondition="integratedMode" resourceType="Unspecified" allowPathInfo="true"/>
    </handlers>
    //  Service Interface project
    public class xxxService   : Service
    {
        public xxxResponse Get(xxxQuery xxxQuery)
        { 
            //return object of type xxxResponse after doing some work to get data
            return new xxxResponse();
        } 
    }
    [Route("/xxxFeature/{xxxSerialNo}/{xxxVersion}")]
    public class xxxQuery
    {
        public string xxxSerialNo { get; set; }
        public string xxxVersion { get; set; }
        public string xxxId { get; set; }
        public string xxxName { get; set; }
    }
    public class xxxResponse : IHasResponseStatus
    {
        public xxxResponse()
        {
            // new up properties in the constructor to prevent null reference issues in the client
            ResponseStatus  = new ResponseStatus();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Size { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
