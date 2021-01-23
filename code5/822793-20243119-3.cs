    u.UserTypeOptions = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Selected = true, Text = string.Empty, Value = "-1"},
                    new SelectListItem { Selected = false, Text = "Homeowner", Value = ((int)UserType.Homeowner).ToString()},
                    new SelectListItem { Selected = false, Text = "Contractor", Value = ((int)UserType.Contractor).ToString()},
                }, "Value" , "Text", 1);
