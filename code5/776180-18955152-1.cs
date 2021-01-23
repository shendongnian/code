    public class ProductionDataViewModel { 
        
       public List<ProductionDataType> ProductionData { get; set; }
       public void Load() {
           ProductionData = from n in db.tbl_dppITHr
            where n.ProductionHour >= SelectedDateDayShiftStart
            where n.ProductionHour <= SelectedDateDayShiftEnd
            select n;
       }
    }
