    public class FancyBinder:DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext
       ,ModelBindingContext bindingContext
       ,Type modelType)
        {
            if (modelType.Name == "BlogEntry")
            {
                return BindBlogEntry(controllerContext, bindingContext, modelType);
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
        private static object BindBlogEntry(ControllerContext controllerContext
       ,ModelBindingContext bindingContext
       ,Type modelType)
        {
            var tagsOnForm = controllerContext.HttpContext.Request.Form["Tags"];
            return new BlogEntry
            {
                Content = controllerContext.HttpContext.Request.Form["Content"],
                Tags = GetTags(tagsOnForm)
            };
        }
        private static List<Tag> GetTags(string tagsOnForm)
        {
            var tags = new List<Tag>();
            if (tagsOnForm == null)
                return tags;
            tagsOnForm.Split(',').ForEach(t=>tags.Add(new Tag {Name = t}));
            return tags;
        }
    }
