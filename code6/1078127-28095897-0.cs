      class Program
        {
            static void Main(string[] args)
            {
                var objectFromServiceA = new ServA_Record();
                objectFromServiceA.RecordAttributes = new List<ServA_Record.ServA_RecordAttribute>();
                objectFromServiceA.RecordName = "Test A";
                objectFromServiceA.RecordAttributes.Add(new ServA_Record.ServA_RecordAttribute() { AttributeName = "Record Attr A", RecordAttributesValues = new List<object>() });
    
                var objectFromServiceB = new ServB_Record();
                objectFromServiceB.RecordAttributes = new List<ServB_Record.ServB_RecordAttribute>();
                objectFromServiceB.RecordName = "Test B";
                objectFromServiceB.RecordAttributes.Add(new ServB_Record.ServB_RecordAttribute() { AttributeName = "Record Attr B", RecordAttributesValues = new List<object>() });
    
                var businessObject = new ObjectType();
    
                Mapper.CreateMap<ServA_Record, ObjectType>();
                Mapper.CreateMap<ServB_Record, ObjectType>();
                Mapper.CreateMap<ServA_Record.ServA_RecordAttribute, ObjectType.ObjectTypeAttribute>();
                Mapper.CreateMap<ServB_Record.ServB_RecordAttribute, ObjectType.ObjectTypeAttribute>();
    
                businessObject = Mapper.Map<ServA_Record, ObjectType>(objectFromServiceA);
                Console.WriteLine(businessObject.RecordName);
                Console.WriteLine(businessObject.RecordAttributes[0].AttributeName);
    
                businessObject = Mapper.Map<ServB_Record, ObjectType>(objectFromServiceB);
                Console.WriteLine(businessObject.RecordName);
                Console.WriteLine(businessObject.RecordAttributes[0].AttributeName);
    
                Console.ReadKey();
            }
        }
    
        public class ServA_Record
        {
            public String RecordName { get; set; }
            public List<ServA_RecordAttribute> RecordAttributes { get; set; }
    
            public class ServA_RecordAttribute
            {
                public String AttributeName { get; set; }
                public List<object> RecordAttributesValues { get; set; }
            }
        }
    
        public class ServB_Record
        {
            public String RecordName { get; set; }
            public List<ServB_RecordAttribute> RecordAttributes { get; set; }
    
            public class ServB_RecordAttribute
            {
                public String AttributeName { get; set; }
                public List<object> RecordAttributesValues { get; set; }
            }
        }
    
        public class ObjectType
        {
            public String RecordName { get; set; }
            public List<ObjectTypeAttribute> RecordAttributes { get; set; }
    
            public class ObjectTypeAttribute
            {
                public String AttributeName { get; set; }
                public List<object> RecordAttributesValues { get; set; }
            }
        }
