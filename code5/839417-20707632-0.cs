    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    namespace test
    {
        public class FbData
        {
            public string id { get; set; }
            public FbCommentBy from { get; set; }
            public string message { get; set; }
            public string can_remove { get; set; }
        }
        public class FbCommentBy
        {
            public string name { get; set; }
            public string id { get; set; }
        }
        public class FbComments
        {
            public List<FbData> data { get; set; }
        }
        public class FbWrapper
        {
            public FbComments comments { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string fbJson = @"{
       'comments':{
          'data':[
             {
                'id':'10202845951538899_6903133',
                'from':{
                   'name':'Name Surname',
                   'id':'1514294282'
                },
                'message':'Statuses Comment',
                'can_remove':true,
                'created_time':'2013-12-11T15:49:35+0000',
                'like_count':0,
                'user_likes':false
             }
          ]
       }
    }";
                FbWrapper wrapper = JsonConvert.DeserializeObject<FbWrapper>(fbJson);
            }
        }
    }
