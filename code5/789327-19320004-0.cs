    abstract class RequestObject
    {
        //properties and methods common to all requests
    }
    class GetRequest : RequestObject
    {
        public GetRequest()
        {
            this.Encoding = System.Text.Encoding.UTF8;
            System.Net.ServicePointManager.Expect100Continue = false;
        }
        //... other specific things for GET
    }
    class PutRequest : RequestObject
    {
        public PutRequest()
        {
            this.AddPostContent(ContentArray);
            this.AddHeader("Content-Type", "application/json");
        }
        //... specific things for PUT
    }
