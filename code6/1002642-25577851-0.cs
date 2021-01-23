    for (int i = 0; i < Model.ListaProdutoCaracteristica.Count; i++) {
      // Generate the hidden inputs this way
      @Html.HiddenFor(m => m.ListaProdutoCaracteristica[i].ProdutoPadraoID)
      // Generate the drop down this way
      @Html.DropDownListFor(m => m.ListaProdutoCaracteristica[i].TipoCaracteristicaID, (SelectList)ViewBag.ListaCaracteristica)
    }
