    public class MemberViewModel : IValidatableObject{
        public int? LocationId { get; set; }
        public int? PillarId { get; set; }  
        public string Title { get; set;}
    }
-----------------------------------------------------------------
    @using (Html.BeginForm("SignUp", "Location", FormMethod.Post))
     ....
     @Html.DropDownListFor(
     model => model.Member.PillarId, new SelectList (Model.Pillars, "Id", "Title"))
     @Html.HiddenFor(model => model.Title);
