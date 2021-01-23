    public class StackOverflow_20806241
    {
        public class Response<T> where T : class
        {
            public string MethodName { get; set; }
            public int ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public List<T> ResponseData { get; set; }
        }
        public class Announcement
        {
            public int AnnouncementId { get; set; }
            public string AnnouncementTitle { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedDate { get; set; }
            public string DataShortVersion { get; set; }
            public string ModifiedBy { get; set; }
            public string ModifiedDate { get; set; }
            public int SortIndex { get; set; }
        }
        public static void Test()
        {
            string JSON = @"{'MethodName':'m1','ResponseCode':1,'ResponseMessage':'msg','ResponseData':[
                {'AnnouncementId':1,'AnnouncementTitle':'t1','CreatedBy':'c1','CreatedDate':'d1','DataShortVersion':'v1','ModifiedBy':'m1','ModifiedDate':'md1','SortIndex':1},
                {'AnnouncementId':2,'AnnouncementTitle':'t2','CreatedBy':'c2','CreatedDate':'d2','DataShortVersion':'v2','ModifiedBy':'m2','ModifiedDate':'md2','SortIndex':2}
            ]}";
            JSON = JSON.Replace('\'', '\"');
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(JSON));
            DataContractJsonSerializer jsonSerializer;
            jsonSerializer = new DataContractJsonSerializer(typeof(Response<Announcement>));
            try
            {
                var objResponse = (Response<Announcement>)jsonSerializer.ReadObject(ms);
                Console.WriteLine("Response:");
                Console.WriteLine("  {0} - {1} - {2}", objResponse.MethodName, objResponse.ResponseCode, objResponse.ResponseMessage);
                Console.WriteLine("  [{0}]", string.Join(", ", objResponse.ResponseData.Select(rd =>
                    string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}",
                        rd.AnnouncementId, rd.AnnouncementTitle,
                        rd.CreatedBy, rd.CreatedDate,
                        rd.DataShortVersion, rd.ModifiedBy,
                        rd.ModifiedDate, rd.SortIndex))));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }
        }
    }
