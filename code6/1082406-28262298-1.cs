    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    static void Main()
    {
    	var xml = @"<?xml version='1.0' encoding='utf-8' ?>
    	            <Root
    	              xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'
                      xmlns:ex='urn:stakx:example'
                    >
    	              <ex:ElementOfInterest xsi:type='ex:ElementOfInterest' />
    	            </Root>";
    
    	var nt = new NameTable();
    	var mgr = new XmlNamespaceManager(nt);
    	mgr.AddNamespace("ex", "urn:stakx:example");
    	var ctxt = new XmlParserContext(nt, mgr, "", XmlSpace.Default);
    	var reader = XmlReader.Create(new StringReader(xml), null, ctxt);
    	var serializer = new XmlSerializer(typeof(ElementOfInterest));
    
    	reader.ReadToFollowing("ElementOfInterest", "urn:stakx:example");
    	var eoi = (ElementOfInterest)serializer.Deserialize(reader.ReadSubtree());
    }
    
    [XmlRoot(Namespace = "urn:stakx:example")]
    public class ElementOfInterest { }
