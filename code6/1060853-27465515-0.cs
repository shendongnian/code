    class Program
        {
            static List<FacultyMember> memberList = new List<FacultyMember>();
            static String filename = @"C:\test.json";
            static void Main(string[] args)
            {
                Save();
                Load();
            }
    
            static void AddNew()
            {
                FacultyMember member = new FacultyMember();
    
                member.firstName = "Test";
                member.lastName = "Test";
                member.email = "test";
                member.ext = "test";
                member.department = "Test";
    
                memberList.Add(member);
    
                Save();
            }
    
            static void Save()
            {
                String json = JsonConvert.SerializeObject(memberList);
                System.IO.File.WriteAllText(filename, json);
            }
    
            static void Load()
            {
               memberList = JsonConvert.DeserializeObject<List<FacultyMember>>(System.IO.File.ReadAllText(filename));
                AddNew();
                Save();
            }
        }
