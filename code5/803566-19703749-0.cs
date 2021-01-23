    @for(int index = 0; index < Model.TransPortationModeList.Count; index++)
    {
        @Html.DropDownListFor(lm => lm.TransPortationModeList[index].TransModeId,
                                    Model.CarrierList.Select(c => new SelectListItem { Text = c.TransportationName + "-" + c.TransportationModelID, Value = c.TransportationModelID }), 
                                    new { @class = "form-control" })
    }
