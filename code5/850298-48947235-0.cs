    public enum ClassDiscriminatorEnum
        {
            ChildClass1,
            ChildClass2
        }
        public abstract class BaseClass
        {
            public abstract ClassDiscriminatorEnum Type { get; }
        }
        public class Child1 : BaseClass
        {
            public override ClassDiscriminatorEnum Type => ClassDiscriminatorEnum.ChildClass1;
            public int ExtraProperty1 { get; set; }
        }
        public class Child2 : BaseClass
        {
            public override ClassDiscriminatorEnum Type => ClassDiscriminatorEnum.ChildClass2;
        }
        public class BaseClassConverter : CustomCreationConverter<BaseClass>
        {
            private ClassDiscriminatorEnum _currentObjectType;
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var jobj = JObject.ReadFrom(reader);
                _currentObjectType = jobj["Type"].ToObject<ClassDiscriminatorEnum>();
                return base.ReadJson(jobj.CreateReader(), objectType, existingValue, serializer);
            }
            public override BaseClass Create(Type objectType)
            {
                switch (_currentObjectType)
                {
                    case ClassDiscriminatorEnum.ChildClass1:
                        return new Child1();
                    case ClassDiscriminatorEnum.ChildClass2:
                        return new Child2();
                    default:
                        throw new NotImplementedException();
                }
            }
        }
