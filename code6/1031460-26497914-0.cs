        [DataContract]
        [KnownType(typeof(Record))]
        public class RecordList
        {
            public RecordList()
            {
                Records = new List<Record>();
            }
    
            [DataMember]
            public List<Record> Records { get; set; }
        }
    
        public class Record
        {
            public Record()
            {
                Attributes = new AttributeList();
            }
    
            [DataMember]
            public AttributeList Attributes { get; set; }
        }
    
    
        [Serializable]
        public class AttributeList : DynamicObject, ISerializable
        {
            private readonly Dictionary<string, object> attributes = new Dictionary<string, object>();
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                attributes[binder.Name] = value;
    
                return true;
            }
    
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                foreach (var kvp in attributes)
                {
                    info.AddValue(kvp.Key, kvp.Value);
                }
            }
        }
    
    
            [Test]
            public void TestSerialize()
            {
                var holder = new RecordList();
    
                dynamic record = new Record();
                record.Attributes.OBJECTID = 1;
                record.Attributes.Address = "380 New York St.";
                record.Attributes.City = "Redlands";
                record.Attributes.Address = "Region";
                record.Attributes.Region = "CA";
                record.Attributes.Postal = "92373";
    
                holder.Records.Add(record);
    
                var stream1 = new MemoryStream();
                var serializer = new DataContractJsonSerializer(typeof(RecordList));
                serializer.WriteObject(stream1, holder);
    
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
                Console.Write("JSON form of holder object: ");
                Console.WriteLine(sr.ReadToEnd());
            }
