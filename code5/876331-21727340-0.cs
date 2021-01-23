    public class ClassA
    {
        public string Type { get; set; }
        public int Value { get; set; }
        public List<ClassB> Details { get; set; }
        public static ClassA FromDataRow(DataRow row, IEnumerable<DataRow> relatedRows)
        {
            var classA = new ClassA
                {
                    Type = (string) row["Type"],
                    Value = (int) row["Value"],
                    Details = relatedRows.Select(r => new ClassB
                        {
                            Name = (string)r["Name"],
                            Age = (int)r["Age"],
                            Gender = (string)r["Gender"]
                        }).ToList()
                };
            return classA;
        }
    }
    public class ClassB
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
