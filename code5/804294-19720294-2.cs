            /// <summary>
    		/// Gets an ActionResult, either as a jsonified string, or rendered as normally
    		/// </summary>
    		/// <typeparam name="TModel">Type of the Model class</typeparam>
    		/// <param name="UsingJson">Do you want a JsonResult?</param>
    		/// <param name="UsingJsonP">Do you want a JsonPResult? (takes priority over UsingJson)</param>
    		/// <param name="Model">The model class instance</param>		
    		/// <param name="RelativePathToView">Where in this webapp is the view being requested?</param>
    		/// <returns>An ActionResult</returns>
    		public ActionResult GetActionResult<T>(T Model, bool UsingJsonP, bool UsingJson, string RelativePathToView)
    		{
    			string ViewAsString =
    				this.RenderView<T>(
    					RelativePathToView,
    					Model
    				);
    
    			if (UsingJsonP) //takes priority
    			{
    				string Callback = this.GetJsonPCallback();
    				JsonPResult Result = this.JsonP(ViewAsString.Trim());
    				return Result;
    			}
    
    			if (UsingJson)//secondary
    			{
    				return Json(ViewAsString.Trim(), JsonRequestBehavior.AllowGet);
    			}
    
    			return View(Model); //tertiary
    		}
