    @using(Html.BeginForm("MyAction", "MyController", new { id=1 })) {
        <input type="submit"/>
        @Html.TextBox("TheValue", "")
    }
    @using(Html.BeginForm("MyAction", "MyController", new { id=2 })) {
        <input type="submit"/>
        @Html.TextBox("TheValue", "")
    }
    public ActionResult MyAction(int? id) {
         // if they click the first one, id is 1
         // if they click the second one, id is 2
    }
