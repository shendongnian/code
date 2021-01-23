    @model   IList<Notsurewhattoname.Controllers.Product>
    
    @{
        ViewBag.Title = "Home Page";
    }
    @using(Html.BeginForm("Index", "Home", FormMethod.Post))
    <table>
        @for (int i = 0; i < Model.Count(); i++)
        {
            
            <tr>
                <td>@Html.LabelFor(m => m[i].Name) </td>
                <td>@Html.DropDownListFor(m => m[i].Stock, Model[i].StockList) </td>
            </tr>	 
        }
    
    </table>
    <input type="submit" value="Submit" />
    }
