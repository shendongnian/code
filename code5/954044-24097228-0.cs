            @Html.DropDownList("statussearch", new List<SelectListItem>
                                        {
                                            new SelectListItem { Text = "text1", Value = "1",  Selected = Studio.IsSelected.HasValue ? Studio.IsSelected.Value : false},
                                            new SelectListItem { Text = "text2", Value = "2"},
                                            new SelectListItem { Text = "text3", Value = "3"},
                                        }, "Select Status")
