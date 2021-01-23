    public class ProductionParameter
    {
       public string CompanyCode { get; set; }
       public string UnitCode { get; set; }
       public string ItemDescriptionLocal { get; set; }
       public string ItemDescriptionEnglish { get; set; }
       public string ConsumedItemDescriptionLocal { get; set; }
       public string ConsumedItemDescriptionEnglish { get; set; }
       public string LotCategory1Description { get; set; }
       public string LotCategory2Description { get; set; }
       public string LotCategory3Description { get; set; }
       public string LotCategory1Code { get; set; }
       public string LotCategory2Code { get; set; }
       public string LotCategory3Code { get; set; }
       public string LineCode { get; set; }
       public string LineCodeDisplay { get; set; }
       public List<Pallet> PalletsProduced { get; set; }
    }
