    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        public void Save(string filePath)
        {
            using (var fs = File.Open(filePath, FileMode.Create))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof (Student));
                serializer.WriteObject(fs, this);
            }
        }
        public static Student Load(string filePath)
        {
            Student result = null; //or default result
            try
            {
                using (var fs = File.OpenRead(filePath))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof (Student));
                    result = serializer.ReadObject(fs) as Student;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
