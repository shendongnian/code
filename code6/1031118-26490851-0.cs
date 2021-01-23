      #region XML Nullable helper properties
      [XmlElement(ElementName = "status1Set")]
      public object status1SetXml
      {
        get
        {
          // Return the main property itself here and not the field to ensure that if there are changes made to the getter,
          // the resulting XML will always have the right value
          return status1Set;
        }
        set
        {
          // value passed in is of type XmlNode[], so convert and get the XmlNode text, which should be the DateTime we want
          // !!ASSUMPTION!! That it will alwas be XmlNode[1] type
          XmlNode[] inputValue = value as XmlNode[];
          if (inputValue != null)
          {
            DateTime.TryParse(Convert.ToString(inputValue[0].InnerText), out status1SetField);
          }
        }
      }
      [XmlElement(ElementName="ccsCreationTime")]
      public object ccsCreationTimeXml
      {
        get
        {
          // Return the main property itself here and not the field to ensure that if there are changes made to the getter,
          // the resulting XML will always have the right value
          return ccsCreationTime;
        }
        set
        {
          // value passed in is of type XmlNode[], so convert and get the XmlNode text, which should be the DateTime we want
          // !!ASSUMPTION!! That it will alwas be XmlNode[1] type
          XmlNode[] inputValue = value as XmlNode[];
          if (inputValue != null)
          {
            DateTime.TryParse(Convert.ToString(inputValue[0].InnerText), out ccsCreationTimeField);
          }
        }
      }
      [XmlElement(ElementName = "customsSummaryTime")]
      public object customsSummaryTimeXml
      {
        get
        {
          // Return the main property itself here and not the field to ensure that if there are changes made to the getter,
          // the resulting XML will always have the right value
          return customsSummaryTime;
        }
        set
        {
          // value passed in is of type XmlNode[], so convert and get the XmlNode text, which should be the DateTime we want
          // !!ASSUMPTION!! That it will alwas be XmlNode[1] type
          XmlNode[] inputValue = value as XmlNode[];
          if (inputValue != null)
          {
            DateTime.TryParse(Convert.ToString(inputValue[0].InnerText), out customsSummaryTimeField);
          }
        }
      }
      [XmlElement(ElementName = "finalised")]
      public object finalisedXml
      {
        get
        {
          // Return the main property itself here and not the field to ensure that if there are changes made to the getter,
          // the resulting XML will always have the right value
          return finalised;
        }
        set
        {
          // value passed in is of type XmlNode[], so convert and get the XmlNode text, which should be the DateTime we want
          // !!ASSUMPTION!! That it will alwas be XmlNode[1] type
          XmlNode[] inputValue = value as XmlNode[];
          if (inputValue != null)
          {
            DateTime.TryParse(Convert.ToString(inputValue[0].InnerText), out finalisedField);
          }
        }
      }
      #endregion
      #region Non XML properties
      [XmlIgnore]
      public System.DateTime status1Set
      {
        get { return this.status1SetField; }
        set { this.status1SetField = value; }
      }
      [XmlIgnore]
      public System.DateTime ccsCreationTime
      {
        get { return this.ccsCreationTimeField; }
        set { this.ccsCreationTimeField = value; }
      }
      [XmlIgnore]
      public System.DateTime customsSummaryTime
      {
        get { return this.customsSummaryTimeField; }
        set { this.customsSummaryTimeField = value; }
      }
    
      [XmlIgnore]
      public System.DateTime finalised
      {
        get { return this.finalisedField; }
        set { this.finalisedField = value; }
      }
      #endregion
