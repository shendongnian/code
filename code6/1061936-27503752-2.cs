    public class GatewaysList : List<Gateway>
    {
          [XmlIgnore]
          public Gateway this[int gatewayId]
          {
            get
            {
               return this.Find(g => g.GatewayId == gatewayId);
            }
          }
            
            
           [XmlArray(ElementName="GatewaysList")]
           [XmlArrayItem(ElementName="Gateway", Type=typeof(Gateway))]
           public List<Gateway> GatewaysList
           {
              get
              {
              }
              set
              {
                  
              }
           }
    }
