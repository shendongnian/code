    var popupTemplate = Properties.Resources.ToolbarTemplate
                .Replace("~T~", typeof (T).ToString())
                .Replace("~userID~", userID)
                .Replace("~GridName~", name)
                .Replace("~ExportAction~", String.Format("/{0}/{1}", dataAccessing.Item2, dataAccessing.Item1));
    .ToolBar(toolbar => toolbar.Template(popupTemplate));
