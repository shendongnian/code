    public class ProductDto : DtoBase
    {
        public int ProductId { get; set; }
        public double Weight { get; set; }
        public int FamilyId { get; set; }
        public override void FillInstance(params string[] parameters)
        {
            ProductId = int.Parse(parameters[0]);
            Weight = double.Parse(parameters[1]);
            FamilyId = int.Parse(parameters[2]);
        }
    }
