    @model LecExamRes.Models.SelectionModel.GroupModel
    @using LecExamRes.Helpers
    @using (Html.BeginForm("Index", "Home", null, FormMethod.Post))
    {
     <div class="mlink">
        @Html.AntiForgeryToken()
        @Html.EncryptedHiddenFor(model => model.GroupKey)
        @Html.EncryptedHiddenFor(model => model.GroupName)
         <p>
             <input type="submit" name="gbtn" class="groovybutton" value=" @Model.GroupKey          ">
         </p>   
     </div>
    }       
