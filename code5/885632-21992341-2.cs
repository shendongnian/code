    public class NewEmployeeModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Blood Group")]
        public int BloodGroup { get; set; }
        public IEnumerable<SelectListItem> BloodGroups { get; set; }
    }
    <div class="form-group">
       @Html.LabelFor(m => m.BloodGroup, new { @class = "control-label col-md-3" })
       <div class="col-md-4">        
          @Html.DropDownListFor(m => m.BloodGroup, Model.BloodGroups, "Please Select", new { @class = "form-control" })
       </div>
    </div>
