    class SomeModel 
    { 
        // You can assume that the base UOM has a conversion rate of 1
        UnitOfMeasure BaseUnitOfMeasure { get; }
        decimal BaseQuantity { get; }
        UnitOfMeasure UnitOfMeasure { get; set; }
 
        decimal Quantity { get { return UnitOfMeasure.Convert(BaseQuantity, BaseUnitOfMeasure); } }
       // or if you are assuming base UOM is conversion rate of 1 then you can just use
       // decimal Quantity { get { return UnitOfMeasure.Convert(BaseQuantity); } }
    }
