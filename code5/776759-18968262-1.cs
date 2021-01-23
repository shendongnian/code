        [HttpPost]
        [ActionName("EditAjax")]
        public ActionResult EditAjaxPOST()
        {
            try
            {
                var viewModel =
                    this.TryCreateModelFromJson<MyModel>(
                        "viewModel");
                this.EditFromModel(viewModel);
                return
                    this.JsonResponse(
                        this.T("Model updated successfuly."),
                        true);
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex, "Error while updating model.");
                return this.JsonResponse(this.T("Error"), false);
            }
        }
