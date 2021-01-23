    @if (Model.ArtikelListe[i].IstKategorie)
    {
      @Html.LabelFor(x => x.ArtikelListe[i].Artikelname)<br />  
      @Html.LabelFor(x => x.ArtikelListe[i].Information)
      @Html.HiddenFor(x => x.ArtikelListe[i].Anzahl) // add this
    }
    else
    {
      if (Model.ArtikelListe[i].MitAnzahl)
      {
        @Html.TextBoxFor(x => x.ArtikelListe[i].Anzahl, new { @class = "field text fn" })
      }
      else
      {
        @Html.LabelFor(x => x.ArtikelListe[i].Anzahl)
        @Html.HiddenFor(x => x.ArtikelListe[i].Anzahl) // add this         
      }
      @Html.LabelFor(x => x.ArtikelListe[i].Artikelname)<br />  
      @Html.LabelFor(x => x.ArtikelListe[i].Information)
    }
