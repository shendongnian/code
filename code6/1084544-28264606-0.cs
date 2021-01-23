    @grid.GetHtml(
        columns: grid.Columns(
            grid.Column("ProductID"),
            grid.Column("Name", null, format:
                @<span>
                   @{
                       char[] arr = (@item.Name).ToCharArray();
                       @Html.DropDownList("Products", null, new string(arr), new { style = "color:red;" });
                    }
               </span>),
                grid.Column("ListPrice", "Price")
        )
    )
