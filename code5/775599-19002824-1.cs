        @model List<ItemViewModel>
        @{
            string oldPrefix = ViewData.TemplateInfo.HtmlFieldPrefix;
            try
            {
                ViewData.TemplateInfo.HtmlFieldPrefix = string.Empty;
                for (int i = 0; i < Model.Count; i++)
                {
                    var item = Model[i];
                    string itemPrefix = string.Format("{0}[{1}]", oldPrefix, i.ToString(CultureInfo.InvariantCulture));
                    @Html.EditorFor(m => item, null, itemPrefix)
                }
            }
            finally
            {
                ViewData.TemplateInfo.HtmlFieldPrefix = oldPrefix;
            }
        }
