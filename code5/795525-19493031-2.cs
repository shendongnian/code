    using System.Xml.Serialization;
    public partial class recipients {
      private recipientsGsm[] itemsField;
    
      /// <remarks/>
      [System.Xml.Serialization.XmlElementAttribute("gsm", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
      public recipientsGsm[] Items {
        get { return this.itemsField; }
        set { this.itemsField = value; }
      }
    }
    public partial class recipientsGsm {
      private string messageIdField;
      private string valueField;
    
      /// <remarks/>
      [System.Xml.Serialization.XmlAttributeAttribute()]
      public string messageId {
        get { return this.messageIdField; }
        set { this.messageIdField = value; }
      }
     
      /// <remarks/>
      [System.Xml.Serialization.XmlTextAttribute()]
      public string Value {
        get { return this.valueField; }
        set { this.valueField = value; }
      }
    }
