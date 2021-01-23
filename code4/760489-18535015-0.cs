    @functions{
        IEnumerable<SelectListItem> GetGenderSelectList(GenderContext genderContext)
        {
           return Enum.GetValues(typeof(Namespace.Models.Enum.Gender)).ToList().ConvertAll(x => new SelectListItem(){Value= x.ToString(), Text= GetGenderDescription(x, genderContext)});
        }
        string GetGenderDescription(Gender gender, GenderContext genderContext)
        {
           switch (GenderContext)
           {
               case Children: return gender == Man? "Boy" : "Girl";
               case Parents: return gender == Man? "Dad" : "Mom";
               default: return gender.ToString();
           }
        }
    }
    
    @Html.DropDownListFor(model => model.Gender, GetGenderSelectList(model.GenderContext))
