    var pickupTimeList = EntityLogic.PopulateTimeSlots(
        vm.DateMileage.PickupDate,
        vm.DateMileage.PickupDate.AddHours(-2), 
        vm.DateMileage.PickupDate.AddHours(2).AddMinutes(15)
    )
    .Select(x => new SelectListItem
    {
        Value = x,
        Text = x,
    });
    ViewBag.PickupTimeList = new SelectList(PickupTimeList, "Value", "Text", "11:00 PM");
