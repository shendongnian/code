     public class RemoteFileInfo
        {
    
            public int CategoryID;
            public string FileName;
            public long Length;
            public string Note;
            public string SFSubmissionID;
            public string SourceInstance;
            public string Subject;
            public int UserID;
            public bool Visibility;
            public int riskID;
            public string fileByteArray;
        }
    
    
        public class ValuesController : ApiController
        {
            [HttpPost]
            public string Test(object incomingInformation)
            {
                JObject deserializedJObject = (JObject)JsonConvert.DeserializeObject(incomingInformation.ToString());
                var convertedRemoteFileInfo = deserializedJObject.ToObject<RemoteFileInfo>();
                return convertedRemoteFileInfo.fileByteArray;
            }
        }
