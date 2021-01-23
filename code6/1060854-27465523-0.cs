    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class Foo
    {
        static String filename = @"C:\test.json";
        public static void Save()
        {
            FacultyMember member = new FacultyMember();
            member.firstName = Guid.NewGuid().ToString();
            member.lastName = "Bar";
            member.email = "Email";
            member.ext = "Ext";
            member.department = "Dept";
            List<FacultyMember> existing = new List<FacultyMember>(); 
            existing.AddRange(Load());
            existing.Add(member);
            String json = JsonConvert.SerializeObject(existing.ToArray());
            System.IO.File.WriteAllText(filename, json);
        }
        public static FacultyMember[] Load()
        {
            if (System.IO.File.Exists(filename))
            {
                using (System.IO.StreamReader re = new System.IO.StreamReader(filename))
                {
                    JsonTextReader reader = new JsonTextReader(re);
                    JsonSerializer se = new JsonSerializer();
                    object obj = se.Deserialize(reader, typeof (FacultyMember[]));
                    return (FacultyMember[]) obj;
                }
            }
            return new FacultyMember[0];
        }
    }
    public class FacultyMember
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String ext { get; set; }
        public String department { get; set; }
        public FacultyMember()
        {
        }
    }
