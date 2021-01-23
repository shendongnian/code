            List<student> data = new List<student>();
            
            student std;
            using (StreamReader output = File.OpenText("student.txt")) 
            {
                JsonSerializer serializer = new JsonSerializer();
                 std = (student)serializer.Deserialize(output, typeof(student));
            }
            data.Add(std);
            
            data.Add(new student()
            {
                id = "25628",
                name = "Marko",
                surname = "Polo",
                adress = "Prague",
                date = "15.1.1998",
                place = "Munchen"
                
            });
            string json = JsonConvert.SerializeObject(data.ToArray());
            System.IO.File.WriteAllText("student.txt", json);
    class student
    {
        public string id {get;set;}
        public string name {get;set;}
        public string surname {get;set;}
        public string adress {get;set;}
        public string date {get;set;}
        public string place{get;set;}
    }
 
