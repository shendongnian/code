        namespace WCF.HTTP.Unity3d
    {
        public class WCFService : IWCFContract
        {
            DataCfg m_dataCfg             = new DataCfg();
    
            Stream SetContext(string str)
            {
                OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
                context.Headers.Add(System.Net.HttpResponseHeader.CacheControl, "public");
                context.ContentType = "text/plain";
                //    context.LastModified = date_image_was_stored_in_database;
                context.StatusCode = System.Net.HttpStatusCode.OK;
    
                return new MemoryStream(UTF8Encoding.Default.GetBytes(str));
            }
    
            Stream IWCFContract.GetRoom(String roomName)
            {
                Loger.Instance.Info("IWCFContract.GetRoom:"+roomName);
                Data_Room data_room = m_dataCfg.ReadXml(roomName);
                string sJson = LitJson.JsonMapper.ToJson(data_room);
                return SetContext(sJson);
            }
            Stream IWCFContract.crossdomain()
            {
                return SetContext("<?xml version='1.0'?><cross-domain-policy><allow-access-from domain=\"*\" to-ports=\"*\" /></cross-domain-policy>");
            }
  
