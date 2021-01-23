        @Html.CheckBoxList("yourtypes", (from o in Model.AllCheckboxOptions
                                            select new SelectListItem
                                            {
                                                Text = o.Value,
                                                Selected = Model.CheckedOptions.Contains(o.Key),
                                                Value = o.Key.ToString()
                                            }).ToList())
