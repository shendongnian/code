    [XmlRoot("data")]
    public class Data
    {
        [XmlArray("products")]
        [XmlArrayItem("product")]
        public Product[] Products { get; set; }
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public Category[] Categories { get; set; }
    }
    public abstract class AbstractNamedNode
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is AbstractNamedNode)
            {
                return string.Equals(((AbstractNamedNode)obj).Name, this.Name);
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return base.GetHashCode();
            }
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
        public virtual T CloneBasic<T>()
            where T: AbstractNamedNode, new()
        {
            T result = new T();
            result.Name = this.Name;
            return result;
        }
    }
    public abstract class AbstractNamedRemovableNode : AbstractNamedNode
    {
        [XmlAttribute("remove")]
        public bool Remove { get; set; }
        public override T CloneBasic<T>()
        {
            var result = base.CloneBasic<T>() as AbstractNamedRemovableNode;
            result.Remove = this.Remove;
            return result as T;
        }
    }
    public class Product : AbstractNamedNode
    {
        [XmlElement("category")]
        public Category[] Categories { get; set; }
    }
    public class Category : AbstractNamedRemovableNode
    {
        [XmlElement("issue")]
        public Issue[] Issues { get; set; }
    }
    public class Issue : AbstractNamedRemovableNode
    {
        // intended blank
    }
