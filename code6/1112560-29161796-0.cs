    @using (Html.BeginForm("Save", "ConnectBatchProduct", FormMethod.Post))
    {
      ....
      for(int i = 0; i < Model.BatchProducts.Count; i++)
      {
        @Html.TextBoxFor(m => m.BatchProducts[i].Quantity)
        @Html.TextBoxFor(m => m.BatchProducts[i].BatchName)
      }
      ....
    }
