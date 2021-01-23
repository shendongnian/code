    @grid.GetHtml(
        columns: grid.Columns(
            grid.Column("ProductID"),
            grid.Column("Name", null, format:
                @<span>
                   grid.Column("Name", null, format:
    @<span>
        @{
                string name = (@item.Name).ToString();
                @Html.DropDownList("Products", null, name , new { style = "color:red;" });
        }
    </span>),
               </span>),
                grid.Column("ListPrice", "Price")
        )
    )
