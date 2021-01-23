        public class yourentity
    {
    public SelectList GenderList{get;set}
    [Required]
    public int gender{get;set;}
    }
    
    public ActionResult youraction()
        {
          yourentity a=new yourentity();
        a.GenderList = new SelectList(new List<SelectListItem>
        {
            new SelectListItem { Text = "Male", Value = "1"},
            new SelectListItem { Text = "Female", Value ="2"},
        });
        return view(a);
        }
    
    in your view
    @Html.DropdownListFor(m=>m.gender,m.GenderList ,"Select Gender")
    @Html.ValidationMessagefor(m=>m.gender)
