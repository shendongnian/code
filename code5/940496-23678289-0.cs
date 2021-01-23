    public class ProductsModel
    {
       [Required]
       public string Name { get; set; }
       public AttributeModel AttributeModel { get; set; }
       public ProductsModel()
       {
         this.AttributeModel =new AttributeModel();
        }
    }
