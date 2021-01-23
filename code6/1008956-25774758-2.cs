    [XmlRootAttribute("VProfilesGroup", IsNullable = false, DataType = "", Namespace = "")]
    public class ProfilesGroup
    {
        static readonly char Delimiter = '\n';
        [XmlIgnore]
        public List<String> ProfilesList { get; set; } // Enhance the setter to throw an exception if any string contains the delimiter.
        [XmlAttribute("ProfilesList")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string ProfilesListText
        {
            get
            {
                return string.Join(Delimiter.ToString(), ProfilesList.ToArray());
            }
            set
            {
                ProfilesList = new List<string>(value.Split(Delimiter));
            }
        }
        public static string CreateGroupXML(List<String> ProfilesList)
        {
            var group = new ProfilesGroup();
            group.ProfilesList = ProfilesList;
            return XmlSerializationHelper.GetXml(group);
        }
        public static List<string> GetProfilesOfGroup(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProfilesGroup));
            var group = (ProfilesGroup)serializer.Deserialize(new StringReader(xml));
            return group == null ? null : group.ProfilesList;
        }
        public static void Test()
        {
            List<string> list = new List<string>(new string[] { "45 65 67", "profilename" });
            var xml = CreateGroupXML(list);
            var newList = GetProfilesOfGroup(xml);
            bool same = list.SequenceEqual(newList);
            Debug.Assert(same); // No assert.
        }
    }
