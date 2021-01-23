    XmlSerializer serializer = new XmlSerializer(typeof(List<Profile>));
    using (StreamReader reader = new StreamReader(File.Open(filename,FileMode.Open)))
    {
        var profiles = (List<Profile>)serializer.Deserialize(reader);
    }
---
    public class Profile
    {
        [XmlAttribute("ProfileID")]
        public string ProfileID { get; set; }
        [XmlAttribute("LastUpdated")]
        public DateTime LastUpdatedDate { get; set; }
        [XmlElement("Job")]
        public List<Job> Jobs { get; set; }
    }
        
    public class Job
    {
        [XmlAttribute("Job_Code")]
        public string JobCode { get; set; }
        [XmlAttribute("Status")]
        public string Status { get; set; }
    }
