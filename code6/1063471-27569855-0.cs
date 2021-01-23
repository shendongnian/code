    public static void SerializeObject(this List<SPSR_ReporteSabanasxOrdenes_Todos_Result> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<SPSR_ReporteSabanasxOrdenes_Todos_Result>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }
