    static List<string> maritalStatuses = new List<string>()
    {
        "Unmarried",
        "Divorced",
        "Widowed",
        "Separated",
        "Annulled"
    };
    public class ProfileViewModel
    {
    
     public string MaritalStatus { get; set; }
      
     public IList<string> MaritalStatuses { get { return maritalStatuses; } }
    }
    @Html.DropDownListFor(model => model.MaritalStatus, 
                          Model.MaritalStatuses.Select(s => new SelectListItem 
                              { 
                                  Text = s, 
                                  Value = s 
                              }, 
                          "--Select One--", 
                          new { @class = "form-control" })
