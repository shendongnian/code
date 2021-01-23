    @{
       var previousItem = "";
    }
    @foreach (var item in Model) {
    <tr>
        <td>
            @if(previousItem != item.InvoiceNumber) 
            {
            previousItem = item.InvoiceNumber.ToString();
            @Html.DisplayFor(modelItem => item.InvoiceNumber)
            }
    
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.ProductName)
        </td>
    
    </tr>
    }
