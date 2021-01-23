    public class UserRoleViewModel
    {
        // Display Attribute will appear in the Html.LabelFor
        [Display(Name = "User Role")]
        public int SelectedUserRoleId { get; set; }
        public IEnumerable<SelectListItem> UserRoles { get; set; }
    }
