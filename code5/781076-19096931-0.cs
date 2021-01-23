    @if (WhiteLabel.Controllers.GlobalVariables.Step == 1)
    {
        @Html.RenderPartial("Step1")
    }
    @if (WhiteLabel.Controllers.GlobalVariables.Step > 2)
    {
        // some default HTML here
        @if (WhiteLabel.Controllers.GlobalVariables.Step == 2)
        {
            @Html.RenderPartial("Step2")
        }
        @if (WhiteLabel.Controllers.GlobalVariables.Step == 3)
        {
            @Html.RenderPartial("Step3")
        }
    }
