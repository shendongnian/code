    	[HttpPost]
		public ActionResult AddPathToSupervisor(string[] ids, string supervisorId)
		{
			try
			{
				PathsBll.AddPathsToSupervisor(ids, supervisorId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Json(ModelState.ToDataSourceResult());
		}
		[HttpPost]
		public ActionResult RemovePathFromSupervisor(string[] ids)
		{
			try
			{
				PathsBll.RemovePathsFromSupervisor(ids);
			}
			
			catch (Exception ex)
			{
				throw ex;
			}
			return Json(ModelState.ToDataSourceResult());
		}
