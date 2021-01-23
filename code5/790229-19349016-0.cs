    @foreach (MvcMedicalStore.Models.MedicalProductViewModelLineItem p in Model.Products)
    {
        @Html.HiddenFor(item => p.ID)
       //rest of the code.
    }
    
    to 
    
    @for ( i = 0;  i <= Model.count(); i++)
    {
        @Html.Hidden(Model[i])
       //rest of the code.
    }
