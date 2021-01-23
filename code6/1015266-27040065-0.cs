    public class ExtendedTemplateBase<TModel> : TemplateBase<TModel>
        {
            public string Partial<TPartialModel>(string path, TPartialModel model)
            {
                var template = File.ReadAllText(path);
                var partialViewResult = Razor.Parse(template, model);
                return partialViewResult;           
            }
        }
