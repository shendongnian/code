    [HttpPost]
    public JsonResult GetAppId(int id)
    {
        context = new SchedulingDataClassesDataContext();
    
        DBAppointment app = context.DBAppointment.FirstOrDefault(x => x.UniqueID == id);
        return Json(app);
    }
