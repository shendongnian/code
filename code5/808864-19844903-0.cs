    <table>
            <tr>
                @foreach (DtoPaymentPlan item in List)
                {
                    <td>@item.Date</td>
                }
            </tr>
            <tr>
                @foreach (DtoPaymentPlan item in List)
                {
                    <td>@item.Description </td>
                }
            </tr>
            <tr>
                @foreach (DtoPaymentPlan item in List)
                {
                    <td>
                        @for (int i = 0; i < item.Docs.Count; i++)
                        {
                            @item.Docs[i]+" " + i.ToString();
                        }
    
                    </td>
    
            
                }
            </tr>
            <tr>
                @foreach (DtoPaymentPlan item in List)
                {
                    <td>@item.Total </td>
    
            
                }
            </tr>
        </table>
