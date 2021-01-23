    //Your custom GeoCoord container
    [DataContractAttribute]
    public class GeoCoordContainer{
      [DataMember]
      public double lat = 0;
      
      [DataMember]
      public double lon = 0;
    
      public GeoCoordContainer(Double lat, Double lon){
        this.lat = lat;
        this.lon = lon;
      }
    }
    
    
    //Then in your Navigated from method
      GeoCoordContainer cont = new GeoCoordContainer(MyGeoPosition.Lattitude,MyGeoPosition.Longitued);
    
      //Now save it to the storage using EZ_Iso
      EZ_Iso.IsolatedStorageAccess.SaveFile("MyLocation",cont);
    
    
     //To Retrieve it from storage 
      GeoCoordContainer cont = (GeoCoordContainer)EZ_Iso.IsolatedStorageAccess.GetFile("MyLocation",typeof(GeoCoordContainer));
