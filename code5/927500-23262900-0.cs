    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    // Your Organization serializer. Override the key methods for the desired date format.
    // This example formats the date as MM/dd/yyyy
    public class YourOrg_JavaScriptSerializer : JavaScriptSerializer
    {
        public string CurrentFormat { get; set; }
        public YourOrg_JavaScriptSerializer(string format)
            : base()
        {
            this.CurrentFormat = format;
            this.RegisterConverters(new JavaScriptConverter[] { new DateStringJSONConverter() });
        }
    }
    public class DateStringJSONConverter : JavaScriptConverter
    {
        private List<Type> supportedTypes;
    
        public DateStringJSONConverter()
        {
            supportedTypes = new List<Type>(1);
            supportedTypes.Add(typeof(DateTime));
        }
        public override object Deserialize(IDictionary<string,Object>
        dictionary, Type type, JavaScriptSerializer serializer)
        {
            var dt = DateTime.ParseExact(dictionary
            ["DateString"].ToString(), GetFormatString(serializer), null);
            return dt;
        }
        private string GetFormatString(JavaScriptSerializer serializer)
        {
            var formatString = "MM/dd/yyyy";
            var mySerializer = serializer as YourOrg_JavaScriptSerializer;
            if (mySerializer != null)
            {
                formatString = mySerializer.CurrentFormat;
            }
            return formatString;
        }
        public override IDictionary<string,Object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var dt = Convert.ToDateTime(obj);
    
            var dicDateTime = new Dictionary<string,Object>(1)
                                  {
                                      {"DateString", dt.ToString(GetFormatString(serializer))}
                                  };
            return dicDateTime;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return this.supportedTypes; }
        }
    }
