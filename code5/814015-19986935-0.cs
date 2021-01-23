    public class SalesFilter{
       public int? MinPrice {get; set;}
       public int? MaxPrice {get; set;}
       public int? IdTypeOfSale {get; set;}
       ...
       ...
       ...
       public IEnumerable<Sale> FilteredValues {get; set;}
       
       //SelectLists if you need that your filters being DropDownLists
       public SelectList TypesOfSales {get; set;}
    }
