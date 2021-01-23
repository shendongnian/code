    <head>
       @Html.Stimulsoft().RenderMvcDesignerScripts()
    </head>
    @(Html.Stimulsoft().StiMvcDesigner(new StiMvcDesignerOptions()
     {
       ActionGetReportTemplate = "GetCardReportSs",
       LocalizationDirectory = Server.MapPath("~/Content/Localization/"), // Necessary to   get a list of available localization files
       ActionDataProcessing = "DataProcessing",
       Width = Unit.Percentage(300),
       Height = Unit.Pixel(800)
     })
    )
