	public class Tag
	{
		public string TagName { get; set; }
	}
	[Serializable()]
	public class BlogViewModel
	{
		[Required]
		[Display(Name = "Title")]
		public string Title { get; set; }
		[Required]
		[Display(Name = "Content")]
		public string Content { get; set; }
			
		public List<Tag> Tags { get; set; }
	}
	public class BlogViewModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			BlogViewModel model;
			if (controllerContext.RequestContext.HttpContext.Request.AcceptTypes.Contains("application/json"))
			{
				var serializer = new JavaScriptSerializer();
				var form = controllerContext.RequestContext.HttpContext.Request.Form.ToString();
				model = serializer.Deserialize<BlogViewModel>(HttpUtility.UrlDecode(form));
			}
			else
			{
				model = (BlogViewModel)ModelBinders.Binders.DefaultBinder.BindModel(controllerContext, bindingContext);
			}
			return model;
		}
	}
