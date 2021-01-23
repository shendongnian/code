    Generate entities with Xsd2Code add-in from www.codeplex.com\Xsd2Code
    
    Use fhir-atom-single.xsd as the source XSD
    Use Parms:
    	Serilization.GenerateXMLAttributes = true
    	Code.Namespace = Hl7.Fhir.Validation.SchematronOutput
    	Collection.CollectionObjectType=Array
    
    !!! Do not open Schema in Designer, or classes will change.
    
    Manual updates:
    
    	public partial class boolean : Element
    	...
            [System.Xml.Serialization.XmlAttributeAttribute("value")]
            public bool Value
            {
    
    
    	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = false, Namespace = "http://www.w3.org/1999/xhtml")]
        public partial class div : Flow
    
    	Refactor:
    	public partial class FeedType
    	to
    	public partial class feed
