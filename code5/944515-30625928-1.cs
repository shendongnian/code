    public ActionResult MyController()
        {
            var SelectedRows = (List<ModelType>)Session["Items"];
            List<ModelType> listStats = SelectedRows;
            // the rest of the controller code
    }
