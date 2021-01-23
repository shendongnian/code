    @Html.BeginForm(){
    @for(int j = 0; j < Model.Items.Count; j++)
    {
        <p>@Model.Items[j].ItemAId</p>
        @Html.HiddenFor(m => m.Items[j].ItemAId)  
        @* (don't forget this!) *@
    
    
        for (int i = 0; i < Model.Items[j].ItemBList.Count; i++)
        {
            @Html.HiddenFor(m => m.Items[j].ItemBList[i].ItemBId )
    
            @Html.TextBoxFor(m => m.Items[j].ItemBList[i].NewInput)
    
        }
    
    }
    <button type="submit">Submit</button>
    }
