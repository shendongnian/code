    grid.Column(
        "TodosLosRoles", 
        "Roles", 
        format: item => Html.DropDownList(((int)item.UserId).ToString(), Model[0].TodosLosRoles)
    )
