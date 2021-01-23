    @using(Html.BeginForm())
    {
        for (var kv = 0; kv < Model.KV.Count(); ++kv)
        {
            @Html.TextBox("KV[" + kv + "].Name", Model.KV.ElementAt(kv).Name);
            @:<br />
            @Html.TextBox("KV[" + kv + "].Value", Model.KV.ElementAt(kv).Value);
            @:<br />
        }
        
        @:<input type="submit" />
    }
