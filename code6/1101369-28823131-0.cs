    public class Program
    {
        
        static void Main(string[] args)
        {
            XDocument xdoc1 = XDocument.Load("file1.xml");
            XDocument xdoc2 = XDocument.Load("file2.xml");
            RootElement file1 = new RootElement(xdoc1.Elements().First());
            RootElement file2 = new RootElement(xdoc2.Elements().First());
            bool isEqual = file1.Equals(file2);
            Console.ReadLine();
        }
    }
    public abstract class ElementBase<T>
    {
        public string Name;
        public List<T> ChildElements;
        public ElementBase(XElement xElement)
        {
        }
    }
    public class RootElement : ElementBase<ChildElement>, IEquatable<RootElement>
    {
        public RootElement(XElement xElement)
            : base(xElement)
        {
            ChildElements = new List<ChildElement>();
            Name = xElement.Name.ToString();
            foreach (XElement e in xElement.Elements())
            {
                ChildElements.Add(new ChildElement(e));
            }
        }
        public bool Equals(RootElement other)
        {
            bool flag = true;
            if (this.ChildElements.Count != other.ChildElements.Count())
            {
                //--Your error handling logic here
                flag = false;
            }
            List<ChildElement> otherChildElements = other.ChildElements;
            foreach (ChildElement c in this.ChildElements)
            {
                ChildElement otherElement = otherChildElements.FirstOrDefault(x => x.Name == c.Name);
                if (otherElement == null)
                {
                    //--Your error handling logic here
                    flag = false;
                }
                else
                {
                    flag = c.Equals(otherElement) == false ? false : flag;
                }
            }
            return flag;
        }
    }
    public class ChildElement : ElementBase<ChildElement>, IEquatable<ChildElement>
    {
        public ChildElement(XElement xElement)
            : base(xElement)
        {
            ChildElements = new List<ChildElement>();
            Name = xElement.Name.ToString();
            foreach (XElement e in xElement.Elements())
            {
                ChildElements.Add(new ChildElement(e));
            }
        }
        public bool Equals(ChildElement other)
        {
            bool flag = true;
            if (this.ChildElements.Count != other.ChildElements.Count())
            {
                //--Your error handling logic here
                flag = false;
            }
            List<ChildElement> otherList = other.ChildElements;
            foreach (ChildElement e in this.ChildElements)
            {
                ChildElement otherElement = otherList.FirstOrDefault(x => x.Name == e.Name);
                if (otherElement == null)
                {
                    //--Your error handling logic here
                    flag = false;
                }
                else
                {
                    flag = e.Equals(otherElement) == false ? false : flag;
                }
            }
            return flag;
        }
    }
