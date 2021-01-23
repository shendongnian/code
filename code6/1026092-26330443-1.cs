    @if (Model.ArtikelListe[i].IstKategorie)
    {
      @Html.LabelFor(x => x.ArtikelListe[i].Artikelname)<br />  
      @Html.LabelFor(x => x.ArtikelListe[i].Information)
    }
    else
    {
      if (Model.ArtikelListe[i].MitAnzahl)
      {
        @Html.TextBoxFor(x => x.ArtikelListe[i].Anzahl, new { @class = "field text fn" })
        <input type="hidden" name="x.ArtikelListe.Index" value="@i" /> // add this manually
      }
      else
      {
        @Html.LabelFor(x => x.ArtikelListe[i].Anzahl)     
      }
      @Html.LabelFor(x => x.ArtikelListe[i].Artikelname)<br />  
      @Html.LabelFor(x => x.ArtikelListe[i].Information)
    }
