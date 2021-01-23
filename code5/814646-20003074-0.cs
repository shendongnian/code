    namespace MessagingConfiguration
    {
        public class InmateDetail
        {
            public InmateDetail(string Pin, int Id)
            { 
                AuthenticatedJsonServiceClient client = new AuthenticatedJsonServiceClient("http://www.test.my.com/MessageService/api/");
               InmateDetailResponse inmateDetail = client.Get(new InmateDetailRequest() { InmatePIN = Pin, FacilityId = Id });
               InmateInboxResponse inmateInbox = client.Get(new InmateInboxRequest() { InmatePkey = inmateDetail.Inmate.pkey.ToString() });
            }    
         }    
      }
