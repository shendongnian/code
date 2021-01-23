    public class ReportDataSource 
    {
        public string Name { get; set; }
        [JsonConverter(typeof(TypedToTypelessCollectionConverter))]
        public ICollection Data { get; set; }
        public static ReportDataSource Deserialize(ReportDataSource dataSourceFromDb, string json)
        {
            using (TypedToTypelessCollectionConverter.SetItemType(dataSourceFromDb == null || dataSourceFromDb.Data == null ? null : dataSourceFromDb.Data.GetType().GetEnumerableTypes().SingleOrDefault()))
            {
                return JsonConvert.DeserializeObject<ReportDataSource>(json);
            }
        }
    }
