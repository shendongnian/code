    class Program
    {
        public interface IPerson { string Speak(); }
        public interface IMale : IPerson { string GrowABeard(); new string Speak();}
        public interface IFemale : IPerson { string Gossip(); new string Speak();}
     
        public class XY : IMale
        {
            private string name = "";
            public XY(string name) { this.name = name; }
            string IMale.GrowABeard() { return string.Format("{0} grows a beard like a male", name); }
            string IMale.Speak() { return string.Format("{0} speaks like a male", name); }
            string IPerson.Speak() { return string.Format("{0} speaks like a male person", name); }
        }
        public class XX : IFemale
        {
            private string name = "";
            public XX(string name) { this.name = name; }
            string IFemale.Gossip() { return string.Format("{0} gossips like a female", name); }
            string IFemale.Speak() { return string.Format("{0} speaks like a female", name); }
            string IPerson.Speak() { return string.Format("{0} speaks like a female person", name); }
        }
        public class XXY : IMale, IFemale
        {
            private string name = "";
            public XXY(string name) { this.name = name; }
            string IMale.GrowABeard() { return string.Format("{0} grows a beard like a male", name); }
            string IMale.Speak() { return string.Format("{0} speaks like a person male", name); }
            string IPerson.Speak() { return string.Format("{0} speaks like a person", name); }
            string IFemale.Speak() { return string.Format("{0} speaks like a person female", name); }
            string IFemale.Gossip() { return string.Format("{0} gossips like a female", name); }
        }
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            foreach (var person in new List<IPerson>() { new XXY("Kai"), new XX("Olivia"), new XY("Liam") })
            {
                if (person is IPerson)
                    sb.AppendLine((person as IPerson).Speak());
                if (person is IMale)
                    sb.AppendLine((person as IMale).Speak());
                if (person is IFemale)
                    sb.AppendLine((person as IFemale).Speak());
            }
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        } 
    }
