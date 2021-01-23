        public void Deserialize()
        {
            var json = @"{
              'response':{  
                '6112':{  
                   'ID':6112,
                   'Title':'Additional Photos',
				},
				'5982':{  
					'ID':5982,
					'Title':'Bike Ride',
				},
				'total_records': '20',
				'returned_count': 10,
				'returned_records': '1-10',
				}
			}";
            var responseObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ss>(json, new ResponseConverter());
            
        }
        public class Response : Dictionary<string, Product>
        {
            public int total_records { get; set; }
            public int returned_count { get; set; }
            public string returned_records { get; set; }
        }
        public class Product
        {
            public string Id { get; set; }
            public string Title { get; set; }
        }
        public class ss
        {
            public Response Response { get; set; }
        }
        public class ResponseConverter : Newtonsoft.Json.JsonConverter
        {
            private Response CreateResponse(Newtonsoft.Json.Linq.JObject jObject)
            {
                //preserve metadata values into variables
                int total_records = jObject["total_records"].ToObject<int>();
                var returned_records = jObject["returned_records"].ToObject<string>();
                var returned_count = jObject["returned_count"].ToObject<int>();
                //remove the unwanted keys
                jObject.Remove("total_records");
                jObject.Remove("returned_records");
                jObject.Remove("returned_count");
                //once, the metadata keys are removed, json.net will be able to deserialize without problem
                var response = jObject.ToObject<Response>();
                //Assign back the metadata to response object
                response.total_records = total_records;
                response.returned_count = returned_count;
                response.returned_records = returned_records;
               //.. now person can be accessed like response['6112'], and
               // metadata can be accessed like response.total_records
                return response;
            }
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Response);
            }
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                var jObject = Newtonsoft.Json.Linq.JObject.Load(reader);
                Response target = CreateResponse(jObject);
                serializer.Populate(jObject.CreateReader(), target);
                return target;
            }
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
