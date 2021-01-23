    [DataContractAttribute]
    public class GeoPostionObj{
       [DataMember]
       Double lat {get;set;}
       [DataMember]
       Double lon {get; set;}
    
       void GeoPositionObj(double lat, double lon){
         this.lat = lat;
         this.lon = lon;
       }
    }
    
