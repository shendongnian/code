    @for (int p = 0; p < Model.InputParameters.Count; p++)
    {
      if (Model.InputParameters[p].DatePicker))
      {
           var id = "datepicker" + p;
           @Html.TextBoxFor(modelitem => Model.InputParameters[p].Value, DateTime.Now.ToString("dd/MM/yyyy"), new { @id = id})
           <script type="text/javascript">
               //var jsondetail2 = '@Html.Raw(Json.Encode(name2))';
               var newname2 = "#@(Html.Raw(id))";//JSON.parse(jsondetail2);
               $(function () {
                   $(newname2).datepicker();
               });
           </script>
      }
    }
