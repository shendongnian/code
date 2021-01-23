    static void Main(string[] args)
            {
                List<List<RecordItem>> combinedList = new List<List<RecordItem>>()
                {
                    new List<RecordItem>()
                    {
                        new RecordItem() { fieldName = "StudentId", value = "S1" },
                        new RecordItem() { fieldName = "Maths", value = "90" },
                        new RecordItem() { fieldName = "Term", value = "1" },
                    },
                    new List<RecordItem>()
                    {
                        new RecordItem() { fieldName = "StudentId", value = "S1" },
                        new RecordItem() { fieldName = "Science", value = "70" },
                        new RecordItem() { fieldName = "Term", value = "1" },
                    }
                };
    
                List<List<RecordItem>> groupedList =
                (
                    from records in combinedList
                    from student in records.Take(1)
                    let StudentId = student.value
                    let Term = records.ToArray().ElementAt(3).value
                    let Subjects = records.Skip(1)
                    group Subjects by new
                    {
                        StudentId,
                        Term
                    }
                        into gss
                        select new[]
                    {
                        new RecordItem() { fieldName = "StudentId", value = gss.Key.StudentId },
                        new RecordItem() { fieldName = "Term", value = gss.Key.Term },
                    }.Concat(gss.SelectMany(x => x)).ToList()
                ).ToList();
            }
