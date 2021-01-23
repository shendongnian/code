	using FluentAssertions;
	using System.Collections.Immutable;
	using System.IO;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Text;
	using System.Xml;
	using Xunit;
	
	namespace ReactiveUI.Ext.Spec
	{
	    [DataContract(Name="Node", Namespace="http://foo.com/")]
	    class Node
	    {
	        [DataMember()]
	        public string Name;
	    }
	
	    [DataContract(Name="Fixture", Namespace="http://foo.com/")]
	    class FixtureType
	    {
	        [DataMember()]
	        public ImmutableList<Node> Nodes;
	
	        public FixtureType(){
	            Nodes = ImmutableList<Node>.Empty.AddRange( new []
	            { new Node(){Name="A"}
	            , new Node(){Name="B"}
	            , new Node(){Name="C"}
	            });
	        }
	    }
	
	
	    public class ImmutableSurrogateSpec
	    {  
	        public static string ToXML(object obj)
	            {
	                var settings = new XmlWriterSettings { Indent = true };
	
	                using (MemoryStream memoryStream = new MemoryStream())
	                using (StreamReader reader = new StreamReader(memoryStream))
	                using (XmlWriter writer = XmlWriter.Create(memoryStream, settings))
	                {
	                    DataContractSerializer serializer =
	                      new DataContractSerializer
	                          ( obj.GetType()
	                          , new DataContractSerializerSettings() { DataContractSurrogate = new ImmutableSurrogateSerializer() }
	                          );
	                    serializer.WriteObject(writer, obj);
	                    writer.Flush();
	                    memoryStream.Position = 0;
	                    return reader.ReadToEnd();
	                }
	            }
	
	        public static T Load<T>(Stream data)
	        {
	            DataContractSerializer ser = new DataContractSerializer
	                  ( typeof(T)
	                  , new DataContractSerializerSettings() { DataContractSurrogate = new ImmutableSurrogateSerializer() }
	                  );
	            return (T)ser.ReadObject(data);
	        }
	
	        public static T Load<T>(string data)
	        {
	            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
	            {
	                return Load<T>(stream);
	            }
	        }
	 
	        [Fact]
	        public void ShouldWork()
	        {
	            var o = new FixtureType();
	 
	            var s = ToXML(o);
	
	            var oo = Load<FixtureType>(s);
	
	            oo.Nodes.Count().Should().Be(3);
	            var names = oo.Nodes.Select(n => n.Name).ToList();
	            names.ShouldAllBeEquivalentTo(new[]{"A", "B", "C"});
	            
	        }
	
	    }
	}
	
