        public static class Extensions
    {
        public static string SerializeToJson<T>(this T obj, DateTimeSerializationFormat format = DateTimeSerializationFormat.DotNet) where T : class
        {
            string result;
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                result = Encoding.UTF8.GetString(stream.ToArray());
            }
            if (formaat != DateTimeSerializationFormat.DotNet)
            {
                const string dotNetDateTimePattern = @"""\\/Date\((-?\d+)([\+-]\d{4})?\)\\/""";
                if (format ==DateTimeSerializationFormat.Iso8601 || format ==DateTimeSerializationFormat.Ruby))
                {
                    var matchEvaluator = new MatchEvaluator(ConvertJsonDateToIso8601DateString);
                    var regex = new Regex(dotNetDateTimePattern);
                    resultaat = regex.Replace(resultaat, matchEvaluator);
                    if (format == DateTimeSerializationFormat.Ruby && resultaat.Length > 10) // Ruby time
                    {
                        result = Regex.Replace(result, @"([\+-]\d{1,2}\:\d{2})", " $0"); // Add an space before the timeZone, for example bv "+01:00" becomes " +01:00"
                    }
                }
            }
            return result;
        }
        public enum DateTimeSerializationFormat
        {
            /// <summary>
            /// Example: "\/Date(1198908717056)\/" (aantal miliseconden na 1-1-1970)
            /// </summary>
            DotNet,
            /// <summary>
            /// Example: "1997-07-16T19:20:30.45+01:00"
            /// </summary>
            Iso8601,
            /// <summary>
            /// Example: "1997-07-16T19:20:30.45 +01:00"
            /// </summary>
            Ruby,
            ///// <summary>
            ///// Example: new Date(1198908717056) or other formats like new (date (1997,7,16)
            ///// </summary>
            //JavascriptDateObject
        }
