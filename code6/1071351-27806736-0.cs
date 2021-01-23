    public class JsonAdapter : JsonResult
    {
        /// <summary>
        /// <para></para>
        /// </summary>
        private const string _dateFormat = "dd/MM/yyyy_HH:mm:ss";
        /// <summary>
        /// <para></para>
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            HttpResponseBase response = context.HttpContext.Response;
            if (!String.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeJavaScriptConverter() });
                response.Write(serializer.Serialize(Data));
            }
        }
    }
    public class DateTimeJavaScriptConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            return new JavaScriptSerializer().ConvertToType(dictionary, type);
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            if (!(obj is DateTime)) return null;
            DateTime data = (DateTime)obj;
            return new DateString(data == DateTime.MinValue || data == DateTime.MaxValue ? string.Empty : data.ToString("dd/MM/yyyy_HH:mm:ss"));
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(DateTime) }; }
        }
        private class DateString : Uri, IDictionary<string, object>
        {
            public DateString(string str) : base(str, UriKind.Relative)
            {
            }
            void IDictionary<string, object>.Add(string key, object value)
            {
                throw new NotImplementedException();
            }
            bool IDictionary<string, object>.ContainsKey(string key)
            {
                throw new NotImplementedException();
            }
            ICollection<string> IDictionary<string, object>.Keys
            {
                get { throw new NotImplementedException(); }
            }
            bool IDictionary<string, object>.Remove(string key)
            {
                throw new NotImplementedException();
            }
            bool IDictionary<string, object>.TryGetValue(string key, out object value)
            {
                throw new NotImplementedException();
            }
            ICollection<object> IDictionary<string, object>.Values
            {
                get { throw new NotImplementedException(); }
            }
            object IDictionary<string, object>.this[string key]
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
            void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }
            void ICollection<KeyValuePair<string, object>>.Clear()
            {
                throw new NotImplementedException();
            }
            bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }
            void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }
            int ICollection<KeyValuePair<string, object>>.Count
            {
                get { throw new NotImplementedException(); }
            }
            bool ICollection<KeyValuePair<string, object>>.IsReadOnly
            {
                get { throw new NotImplementedException(); }
            }
            bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }
            IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
            {
                throw new NotImplementedException();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
