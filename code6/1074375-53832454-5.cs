    [BindProperty]
    public int User User { get; set; } = 1;
    public List<SelectListItem> Roles { get; set; }
    public void OnGet()
    {
        Roles = new List<SelectListItem> {
            new SelectListItem { Value = "1", Text = "X" },
            new SelectListItem { Value = "2", Text = "Y" },
            new SelectListItem { Value = "3", Text = "Z" },
       };
    }
    <select asp-for="User" asp-items="Model.Roles">
        <option value="">Select Role</option>
    </select>
