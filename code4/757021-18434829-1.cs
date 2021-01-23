     VehicleViewModel viewModel = new VehicleViewModel
     {
        Vehicle vehicle  = <populate via Linq query>
        VehicleTypes = VehicleTypes.Select(x => new SelectListItem
        {
            Value = x.VehicleTypeID,
            Text = VehicleTypeDescription 
        }).ToList(),
              
        vehicle = vehicle
     };
