    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace DynaXmlSer {
    
    	public class KnownTypesXmlReader: XmlTextReader {
    		public KnownTypesXmlReader(Stream ios): base(ios) {}
    		public Type[] ExtraTypes = null;
    	}
    
    	public partial class SerializableSortedDictionary<TKey, TVal>
    		: SortedDictionary<TKey, TVal>, IXmlSerializable
    	{
    		public void SetKnownTypes(Type[] extraTypes) {
    			this.extraTypes = extraTypes;
    			valueSerializer = null;
    			keySerializer = null;
    		}
    		void IXmlSerializable.ReadXml(System.Xml.XmlReader reader) {
    			if (reader.IsEmptyElement)
    				return;
    			if (!reader.Read())
    				throw new XmlException("Error in Deserialization of Dictionary");
    
    			//HERE IS THE TRICK
    			if (reader is KnownTypesXmlReader)
    				SetKnownTypes(((KnownTypesXmlReader)reader).ExtraTypes);
    
    			//reader.ReadStartElement(DictionaryNodeName);
    			while (reader.NodeType != XmlNodeType.EndElement)
    			{
    				reader.ReadStartElement(ItemNodeName);
    				reader.ReadStartElement(KeyNodeName);
    				TKey key = (TKey)KeySerializer.Deserialize(reader);
    				reader.ReadEndElement();
    				reader.ReadStartElement(ValueNodeName);
    				TVal value = (TVal)ValueSerializer.Deserialize(reader);
    				reader.ReadEndElement();
    				reader.ReadEndElement();
    				this.Add(key, value);
    				reader.MoveToContent();
    			}
    			//reader.ReadEndElement();
    
    			reader.ReadEndElement(); // Read End Element to close Read of containing node
    		}
    
    	}
    
    	public class BasicElement {
    		private string name;
    		public string Name {
    			get { return name; }
    			set { name = value; } }
    	}
    	public class ElementOne: BasicElement {
    		private string one;
    		public string One {
    			get { return one; }
    			set { one = value; }
    		}
    	}
    	public class ElementTwo: BasicElement {
    		private string two;
    		public string Two {
    			get { return two; }
    			set { two = value; }
    		}
    	}
    
    	public class Program {
    		static void Main(string[] args) {
    			Type[] extraTypes = new Type[] { typeof(ElementOne), typeof(ElementTwo) };
    			SerializableSortedDictionary<string, BasicElement> dict = new SerializableSortedDictionary<string,BasicElement>();
    			dict.SetKnownTypes(extraTypes);
    			dict["foo"] = new ElementOne() { Name = "foo", One = "FOO" };
    			dict["bar"] = new ElementTwo() { Name = "bar", Two = "BAR" };
    
    			XmlSerializer ser = new XmlSerializer(typeof(SerializableSortedDictionary<string, BasicElement>));
    
    			MemoryStream mem = new MemoryStream();
    			ser.Serialize(mem, dict);
    			Console.WriteLine(Encoding.UTF8.GetString(mem.ToArray()));
    			mem.Position = 0;
    
    			using(XmlReader rd = new KnownTypesXmlReader(mem) { ExtraTypes = extraTypes })
    				dict = (SerializableSortedDictionary<string, BasicElement>)ser.Deserialize(rd);
    
    			foreach(KeyValuePair<string, BasicElement> e in dict) {
    				Console.Write("Key = {0}, Name = {1}", e.Key, e.Value.Name);
    				if(e.Value is ElementOne) Console.Write(", One = {0}", ((ElementOne)e.Value).One);
    				else if(e.Value is ElementTwo) Console.Write(", Two = {0}", ((ElementTwo)e.Value).Two);
    				Console.WriteLine(", Type = {0}", e.Value.GetType().Name);
    			}
    		}
    	}
    
    	[Serializable]
    	[XmlRoot("dictionary")]
    	public partial class SerializableSortedDictionary<TKey, TVal>
    		: SortedDictionary<TKey, TVal>, IXmlSerializable
    	{
    		#region Constants
    		private const string DictionaryNodeName = "Dictionary";
    		private const string ItemNodeName = "Item";
    		private const string KeyNodeName = "Key";
    		private const string ValueNodeName = "Value";
    		#endregion
    
    		#region Constructors
    		public SerializableSortedDictionary()
    		{
    		}
    
    		public SerializableSortedDictionary(IDictionary<TKey, TVal> dictionary)
    		: base(dictionary)
    		{
    		}
    
    		public SerializableSortedDictionary(IComparer<TKey> comparer)
    		: base(comparer)
    		{
    		}
    
    		public SerializableSortedDictionary(IDictionary<TKey, TVal> dictionary, IComparer<TKey> comparer)
    		: base(dictionary, comparer)
    		{
    		}
    
    		#endregion
    
    		#region IXmlSerializable Members
    
    		void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
    		{
    			//writer.WriteStartElement(DictionaryNodeName);
    			foreach (KeyValuePair<TKey, TVal> kvp in this)
    			{
    				writer.WriteStartElement(ItemNodeName);
    				writer.WriteStartElement(KeyNodeName);
    				KeySerializer.Serialize(writer, kvp.Key);
    				writer.WriteEndElement();
    				writer.WriteStartElement(ValueNodeName);
    				ValueSerializer.Serialize(writer, kvp.Value);
    				writer.WriteEndElement();
    				writer.WriteEndElement();
    			}
    			//writer.WriteEndElement();
    		}
    
    		System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
    		{
    			return null;
    		}
    
    
    		public Type[] extraTypes = null;
    
    		#endregion
    
    		#region Private Properties
    		protected XmlSerializer ValueSerializer
    		{
    			get
    			{
    				if (valueSerializer == null)
    				{
    					if (extraTypes == null)
    						valueSerializer = new XmlSerializer(typeof(TVal));
    					else
    						valueSerializer = new XmlSerializer(typeof(TVal), extraTypes);
    				}
    				return valueSerializer;
    			}
    		}
    
    		private XmlSerializer KeySerializer
    		{
    			get
    			{
    				if (keySerializer == null)
    				{
    					if (extraTypes == null)
    						keySerializer = new XmlSerializer(typeof(TKey));
    					else
    						keySerializer = new XmlSerializer(typeof(TKey), extraTypes);
    				}
    				return keySerializer;
    			}
    		}
    		#endregion
    		#region Private Members
    		[NonSerialized]
    		private XmlSerializer keySerializer = null;
    		[NonSerialized]
    		private XmlSerializer valueSerializer = null;
    		#endregion
    	}
    
    }
