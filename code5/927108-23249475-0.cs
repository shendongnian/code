    @using WebApplication2.Controllers
    @model WebApplication2.Controllers.MyModel
    @{
        ViewBag.Title = "Home Page";
        ViewBag.FleetType = new SelectList(
            VehicleOwnerFleetTypeFactory.GetTypes().OrderBy(l => l.Type),
            "Id", 
            "Type");
    }
    
    <div>
        <h2>---------------------------</h2>
    
        @Html.DropDownListFor(model => model.FleetType,
                (SelectList)ViewBag.FleetType)
        <h2>---------------------------</h2>
    </div>
