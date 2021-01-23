    @using(Html.BeginForm("MyAction", "MyController", new { id=1 })) {
        <input type="submit"/>
        @Html.TextBox("TheValue", "One")
    }
    @using(Html.BeginForm("MyAction", "MyController", new { id=2 })) {
        <input type="submit"/>
        @Html.TextBox("TheValue", "Two")
    }
    public ActionResult MyAction(int? id, string TheValue) {
         // if they click the first one, id is 1, TheValue = "One"
         // if they click the second one, id is 2, TheValue = "Two"
    }
