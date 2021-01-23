    [DataContractAttribute]
    public class GeoPostionObj{
       [DataMember]
       Double lat {get;set;}
       [DataMember]
       Double lon {get; set;}
    
       public GeoPositionObj(double lat, double lon){
         this.lat = lat;
         this.lon = lon;
       }
    }
    
