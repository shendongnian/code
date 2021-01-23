    class Program
    {
        public static string FileName = @"FamilyTree.xml";
    
        static void Main(string[] args)
        {
            // make some members
            var rootMember = new Member() { Name = "Johny" };
            var member1 = new Member() { Name = "Andy" };
            var member2 = new Member() { Name = "Adam" };
            var member3 = new Member() { Name = "Andrew" };
            var member4 = new Member() { Name = "Davis" };
            var member5 = new Member() { Name = "Simon" };
    
            // construct some arbitrary references between them
            member1.Reference = member4;
            member3.Reference = member1;
            member5.Reference = member2;
    
            // add all of the to the family tree
            rootMember.FamilyTree.Add(member1);
            rootMember.FamilyTree.Add(member2);
            rootMember.FamilyTree.Add(member3);
            member2.FamilyTree.Add(member4);
            member4.FamilyTree.Add(member5);
    
            var familyTree = new GenericCollection() { rootMember };
    
            IFamilyTreeFile file = new FamilyTreeFile()
            {
                FamilyTree = familyTree
            };
    
            Console.WriteLine("--- input ---");
            Serialize(file);
            PrintTree(file.FamilyTree, 0);
            Console.WriteLine();
            Console.WriteLine("--- output ---");
            file = Deserialize();
            file.FamilyTree.RebuildReferences(file.FamilyTree); // this is where the refereces
            // are put together again after deserializing the object tree.
            PrintTree(file.FamilyTree, 0);
            Console.ReadLine();
        }
    
        private static void PrintTree(GenericCollection c, int indent)
        {
            foreach (var member in c)
            {
                string line = member.Name.PadLeft(indent, ' ');
                if (member.Reference != null)
                {
                    line += " (Ref: " + member.Reference.Name + ")";
                }
                Console.WriteLine(line);
                PrintTree(member.FamilyTree, indent + 4);
            }
        }
    
        public static void Serialize(IFamilyTreeFile obj)
        {
            var xmlSerializer = new XmlSerializer(typeof(FamilyTreeFile));
            using (TextWriter writer = new StreamWriter(FileName))
            {
                xmlSerializer.Serialize(writer, obj);
            }
        }
    
        public static IFamilyTreeFile Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FamilyTreeFile));
            using (Stream stream = File.Open(FileName, FileMode.Open))
            {
                return (IFamilyTreeFile)serializer.Deserialize(stream);
            }
        }
    }
    
    public interface IMember
    {
        Guid ID { get; set; }
        string Name { get; set; }
        IMember Reference { get; set; }
        Guid ReferenceID { get; set; }
        GenericCollection FamilyTree { get; set; }
        void RebuildReferences(GenericCollection in_Root);
    }
    
    [Serializable]
    public class Member : IMember
    {
        private GenericCollection _FamilyTree;
        private IMember _Reference;
    
        [XmlAttribute]
        public Guid ID { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public Guid ReferenceID { get; set; }
        [XmlIgnore]
        public IMember Reference
        {
            get { return _Reference; }
            set
            {
                ReferenceID = value.ID;
                _Reference = value;
            }
        }
    
        public GenericCollection FamilyTree
        {
            get { return _FamilyTree; }
            set
            {
                _FamilyTree = value;
                _FamilyTree.Owner = this;
            }
        }
    
        public Member()
        {
            ID = Guid.NewGuid();
            FamilyTree = new GenericCollection();
        }
    
        public void RebuildReferences(GenericCollection in_Root)
        {
            if (!ReferenceID.Equals(Guid.Empty))
                Reference = in_Root.FindMember(ReferenceID);
    
            FamilyTree.RebuildReferences(in_Root);
        }
    }
    
    [Serializable]
    public class GenericCollection : List<IMember>, IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
    
        private IMember _Owner;
        public IMember Owner
        {
            get { return _Owner; }
            set
            {
                _Owner = value;
            }
        }
    
        public void Add(IMember item)
        {
            base.Add(item);
        }
    
        public void ReadXml(XmlReader reader)
        {
            // no need to advace upfront so MoveToContent was taken out (would mess with subsequent inner deserializations anyway)
            if (reader.Name == "FamilyTree")
            {
                do
                {
                    if (reader.Name == "Member" && reader.IsStartElement())
                    {
                        Type type = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                        .Where(x => x.Name == reader.Name)
                        .FirstOrDefault();
                        if (type != null)
                        {
                            var xmlSerializer = new XmlSerializer(type);
                            var member = (IMember)xmlSerializer.Deserialize(reader);
                            this.Add(member);
                        }
                        continue; // to omit .Read because Deserialize did already advance us to next element
                    }
    
                    if (reader.Name == "FamilyTree" && reader.NodeType == System.Xml.XmlNodeType.EndElement)
                        break;
    
                    reader.Read();
                }
                while (!reader.EOF);
            }
        }
    
        public void WriteXml(XmlWriter writer)
        {
            foreach (IMember rule in this)
            {
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(String.Empty, String.Empty);
                XmlSerializer xmlSerializer = new XmlSerializer(rule.GetType());
                xmlSerializer.Serialize(writer, rule, namespaces);
            }
        }
    
        public void RebuildReferences(GenericCollection in_Root)
        {
            foreach (IMember meber in this)
            {
                meber.RebuildReferences(in_Root);
            }
        }
    
        public IMember FindMember(Guid in_ID)
        {
            IMember FoundMember = null;
            foreach (IMember member in this)
            {
                if (member.ID.Equals(in_ID))
                    return member;
    
                FoundMember = member.FamilyTree.FindMember(in_ID);
                if (FoundMember != null)
                    return FoundMember;
            }
            return null;
        }
    }
    
    public interface IFamilyTreeFile
    {
        GenericCollection FamilyTree { get; set; }
    }
    
    public class FamilyTreeFile : IFamilyTreeFile
    {
        public GenericCollection FamilyTree { get; set; }
    }
