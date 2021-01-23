    @using (Html.BeginForm("Edit", "Home", FormMethod.Post, Model))
    {
        int listNumber = 0;
        <div id="lll">
            
            @Html.TextBoxFor(m => m.ATempProperty)      
            @foreach(WebApplication1.Models.GridModel l in Model.GridList)
            {
                @Html.HiddenFor(m => m.GridList[listNumber].GridName);
                @Html.HiddenFor(m => m.GridList[listNumber].PageRecordCount);            
            }           
        </div>
        
        <input type="submit" value="Submit" />
    }
