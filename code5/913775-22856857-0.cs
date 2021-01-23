    <a href="@Url.Action("Klantoverzicht", "Winkelmand", 
             new { 
                   pId = Model.ProductID,
                   mark = Model.Merk,
                   name = Model.Naam,
                   price = Model.Prijs,
                   number = Model.Aantal,
                 })">Bestel!</a>
