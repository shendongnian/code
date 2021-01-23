    abstract class AbstractImporter 
    {
        public abstract List<SoldProduct> FeatchData();
        public bool UploadData(List<SoldProduct> productsSold)
        {
            // here you can do code to save data in common destination 
        }
    }
    public class ExcelImporter : AbstractImporter 
    {
      public override List<SoldProduct> FeatchData()
      {
      // here do code to get data from excel
      }
    }
    public class XMLImporter : AbstractImporter 
    {
      public override List<SoldProduct> FeatchData()
      {
      // here do code to get data from XML
      }
    }
    public class AccessDataImporter : AbstractImporter 
    {
      public override List<SoldProduct> FeatchData()
      {
      // here do code to get data from Access database
      }
    }
