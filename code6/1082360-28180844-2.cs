    @{
        // Assume that someVar is provided from somewhere else; 
        // this is just for demonstration
        var someVar = new { Prop1 = "My Prop", Prop2 = "Prop Value", Prop3 = 7 };
    }
    @{
        var obj = new Dictionary<string, object>
        {
            {someVar.Prop1, new object[] { someVar.Prop2, someVar.Prop3 } }
        };
    }
    <script>
        var stuff = @Html.Raw(Json.Encode(obj));
    </script>
