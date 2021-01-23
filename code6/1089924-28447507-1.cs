    @model VehicleViewModel
    @using(Html.BeginForm())
    {
      // controls for VehicleTypeName, LocationName
      for(int i = 0; i < Model.AssignedProducts.Count; i++)
      {
        @Html.HiddenFor(m => m.AssignedProducts[i].ProductID) // ditto for ProductName if you want it on postback
        @Html.CheckBoxFor(m => m.AssignedProducts[i].IsSelected)
        @Html.LabelFor(m => m.AssignedProducts[i].IsSelected, Model.AssignedProducts[i].ProductName)
      }
      ....
    }
