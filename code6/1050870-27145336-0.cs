    @{ // you can put the following in a back-end method and pass through ViewBag
       var selectList = Enum.GetValues(typeof(UserStatus))
                            .Cast<UserStatus>()
                            .Where(e => e != UserStatus.Pending)
                            .Select(e => new SelectListItem 
                                { 
                                    Value = ((int)e).ToString(),
                                    Text = e.ToString()
                                });
    }
    @Html.DropDownListFor(m => m.Status, selectList)
