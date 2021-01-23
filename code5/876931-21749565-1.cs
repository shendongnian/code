    [HttpGet]
    public ActionResult Alarms_Read([DataSourceRequest] DataSourceRequest request, int id, DateTime? startDate, DateTime? endDateFilter)
    {
        var unit = UnitClient.GetUnit(id);
        var fromDate = startDate ?? DateTime.Today.AddDays(-20);
        var toDate = endDateFilter ?? DateTime.Now;
        Model = new AlarmsViewModel
        {
            ViewUnitContract = UnitClient.GetUnit(id),
            Alarms = AlarmClient.GetAlarmsForUnit(unit.Name, fromDate, toDate)
                .Where(x => x.DateOff == null || x.DateAck == null)
                .ToArray(),
            UnitName = unit.Name,
            Unit = new UnitDetailsModel(unit),
            FromTime = fromDate,
            ToTime = toDate
        };
        return Json(Model.Alarms.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
    }
