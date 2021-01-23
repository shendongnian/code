    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- array of calls ---");
            DeserializeAndDumpCallsList(@"
            {
                ""response"": {
                    ""method"": ""switchvox.currentCalls.getList"",
                    ""result"": {
                        ""current_calls"": {
                            ""current_call"": [
                                {
                                    ""provider"": ""ThinkTel"",
                                    ""start_time"": ""2014-11-30 02:24:52"",
                                    ""duration"": ""5"",
                                    ""to_caller_id_number"": ""800"",
                                    ""state"": ""ivr"",
                                    ""from_caller_id_name"": ""<unknown>"",
                                    ""to_caller_id_name"": ""Main Answer Queue"",
                                    ""format"": ""ulaw"",
                                    ""from_caller_id_number"": ""9999999999"",
                                    ""id"": ""SIP/1234567890-08682a00""
                                },
                                {
                                    ""provider"": ""ThinkTel"",
                                    ""start_time"": ""2014-11-30 02:24:50"",
                                    ""duration"": ""7"",
                                    ""to_caller_id_number"": ""800"",
                                    ""state"": ""ivr"",
                                    ""from_caller_id_name"": ""<unknown>"",
                                    ""to_caller_id_name"": ""Main Answer Queue"",
                                    ""format"": ""ulaw"",
                                    ""from_caller_id_number"": ""1111111111"",
                                    ""id"": ""SIP/9876543210-08681350""
                                }
                            ],
                            ""total_items"": ""2""
                        }
                    }
                }
            }");
            Console.WriteLine("--- single call ---");
            DeserializeAndDumpCallsList(@"
            {
                ""response"": {
                    ""method"": ""switchvox.currentCalls.getList"",
                    ""result"": {
                        ""current_calls"": {
                            ""current_call"": {
                                ""provider"": ""Internal"",
                                ""start_time"": ""2014-11-30 19:15:44"",
                                ""duration"": ""250"",
                                ""to_caller_id_number"": ""777"",
                                ""state"": ""talking"",
                                ""from_caller_id_name"": ""<unknown>"",
                                ""to_caller_id_name"": ""<unknown>"",
                                ""format"": ""ulaw->ulaw"",
                                ""from_caller_id_number"": ""231"",
                                ""id"": ""SIP/231-b4066e90""
                            },
                            ""total_items"": ""1""
                        }
                    }
                }
            }");
            Console.WriteLine("--- no current call ---");
            DeserializeAndDumpCallsList(@"
            {
                ""response"": {
                    ""method"": ""switchvox.currentCalls.getList"",
                    ""result"": {
                        ""current_calls"": {
                            ""total_items"": ""0""
                        }
                    }
                }
            }");
        }
        private static void DeserializeAndDumpCallsList(string json)
        {
            var root = JsonConvert.DeserializeObject<RootObject>(json);
            List<CurrentCall> calls = root.response.result.current_calls.current_call;
            if (calls != null)
            {
                foreach (CurrentCall call in calls)
                {
                    Console.WriteLine(call.from_caller_id_number);
                }
            }
            else
            {
                Console.WriteLine("no calls");
            }
            Console.WriteLine();
        }
        public class RootObject
        {
            public Response response { get; set; }
        }
        public class Response
        {
            public string method { get; set; }
            public Result result { get; set; }
        }
        public class Result
        {
            public CurrentCalls current_calls { get; set; }
        }
        public class CurrentCalls
        {
            [JsonConverter(typeof(SingleOrArrayConverter<CurrentCall>))]
            public List<CurrentCall> current_call { get; set; }
            public string total_items { get; set; }
        }
        public class CurrentCall
        {
            public string provider { get; set; }
            public string start_time { get; set; }
            public string duration { get; set; }
            public string to_caller_id_number { get; set; }
            public string state { get; set; }
            public string from_caller_id_name { get; set; }
            public string to_caller_id_name { get; set; }
            public string format { get; set; }
            public string from_caller_id_number { get; set; }
            public string id { get; set; }
        }
        class SingleOrArrayConverter<T> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(List<T>));
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JToken token = JToken.Load(reader);
                if (token.Type == JTokenType.Array)
                {
                    return token.ToObject<List<T>>();
                }
                return new List<T> { token.ToObject<T>() };
            }
            public override bool CanWrite
            {
                get { return false; }
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
