    public class  ListDevicesByLabelModel
    { 
         public ListDevicesByLabelModel Clone()
         {
              var newObj = new ListDevicesByLabelModel();
              newObj.SomeProperty = SomeProperty;
              //assign other properites
              return newObj;
         }
    }
