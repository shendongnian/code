    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class survey
    {
      private surveyQuestion[] questionField;
      /// <remarks/>
      [System.Xml.Serialization.XmlElementAttribute("question")]
      public surveyQuestion[] question
      {
        get
        {
          return this.questionField;
        }
        set
        {
          this.questionField = value;
        }
      }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class surveyQuestion
    {
      private string typeField;
      private string textField;
      private string[] choicesField;
      /// <remarks/>
      public string type
      {
        get
        {
          return this.typeField;
        }
        set
        {
          this.typeField = value;
        }
      }
      /// <remarks/>
      public string text
      {
        get
        {
          return this.textField;
        }
        set
        {
          this.textField = value;
        }
      }
      /// <remarks/>
      [System.Xml.Serialization.XmlArrayItemAttribute("choice", IsNullable = false)]
      public string[] choices
      {
        get
        {
          return this.choicesField;
        }
        set
        {
          this.choicesField = value;
        }
      }
    }
