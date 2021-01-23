    @foreach (MvcMedicalStore.Models.MedicalProductViewModelLineItem p in Model.Products)
    {
        @Html.HiddenFor(item => p.ID)
       //rest of the code.
    }
    
    to 
    
    @for ( i = 0;  i < Model.count(); i++)
    {
      @Html.LabelFor(m => m[i].Name)
      @Html.HiddenFor(m => m[i].Name)
      @Html.LabelFor(m => m[i].Price)
      @Html.EditorFor(m => m[i].Price)
       //rest of the code.
    }
    [HttpPost]
     public MedicalProductViewModel GetMedicalProductViewModel(ICollection<MedicalProduct> productList)
        {
            var brandList = _db.Brands.ToArray();
    
            var mapper = new MedicalProductMapper();
    
            return mapper.MapMedicalProductViewModel(productList, brandList);            
        }
