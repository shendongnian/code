    [HttpPost]
    public JsonResult ToolTips(string viewName)
    {
        List<ToolTipMvc.Models.ToolTipMvcModel> result = ToolTipMvc.Models.ToolTipMvcModel.GetToolTip(viewName);
        return Json(result);
    }
