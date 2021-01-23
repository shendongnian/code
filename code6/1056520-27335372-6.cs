    public class MyValueConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context,
           Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context,
           CultureInfo culture, object value)
        {
            if (value is string)
            {
                // Cannot do JsonConvert.DeserializeObject here because it will cause a stackoverflow exception.
                using (var reader = new JsonTextReader(new StringReader((string)value)))
                {
                    JObject item = JObject.Load(reader);
                    if (item == null)
                        return null;
                    MyValue myValue = new MyValue();
                    var prop1 = item["Prop1"];
                    if (prop1 != null)
                        myValue.Prop1 = prop1.ToString();
                    var prop2 = item["Prop2"];
                    if (prop2 != null)
                        myValue.Prop2 = prop2.ToString();
                    return myValue;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context,
           CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                MyValue myValue = (MyValue)value;
                // Cannot do JsonConvert.SerializeObject here because it will cause a stackoverflow exception.
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture))
                using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Prop1");
                    jsonWriter.WriteValue(myValue.Prop1);
                    jsonWriter.WritePropertyName("Prop2");
                    jsonWriter.WriteValue(myValue.Prop2);
                    jsonWriter.WriteEndObject();
                    return sw.ToString();
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    [TypeConverter(typeof(MyValueConverter))]
    public class MyValue
    {
        public MyValue()
        {
        }
        public MyValue(string prop1, string prop2)
        {
            this.Prop1 = prop1;
            this.Prop2 = prop2;
        }
        public String Prop1 { get; set; }
        public String Prop2 { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            else if (ReferenceEquals(obj, null))
                return false;
            if (GetType() != obj.GetType())
                return false;
            var other = (MyValue)obj;
            return Prop1 == other.Prop1 && Prop2 == other.Prop2;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                uint code = 0;
                if (Prop1 != null)
                    code ^= (uint)Prop1.GetHashCode();
                code = (code << 16) | (code >> 16);
                if (Prop2 != null)
                    code ^= (uint)Prop2.GetHashCode();
                return (int)code;
            }
        }
        public override string ToString()
        {
            return TypeDescriptor.GetConverter(GetType()).ConvertToString(this);
        }
    }
