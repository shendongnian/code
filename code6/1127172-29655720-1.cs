        [Route("api/data/{id:int}.js")]
        protected async Task<PartialViewResult> GetData(int id, string locale)
        {
            try
            {
                Response.ContentType = "application/javascript";
                ViewBag.Locale = locale ?? "en";
                var model = await this._dataService.GetData(id.ToString());
                return PartialView(model);
            }
            catch (Exception ex)
            {
                this._logger.Error("Task<PartialViewResult> GetData(int, string)", ex);
                return PartialView("JavaScriptError", SelectException(ex));
            }
        }
