    >     public class CatalogView
    >     {
    >         public IEnumerable<CatalogModel> Catalog;
    >         public IEnumerable<Device> Devices;
    >     
    >         public CatalogView(IEnumerable<CatalogModel> catalog = null, IEnumerable<Device> devices = null)
    >         {
    >             Catalog = catalog;
    >             Devices = devices;
    >         }
    >     public CatalogView ()
    >     {
    >     Catalog = new List<CatalogModel>();
    >     Devices = new List<Device>();
    >     }
    >     }
