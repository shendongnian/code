   		public MyContext GetContext()
		{
			if (System.Web.HttpContext.Current.Items["MyScopedContext"] == null)
			{
				System.Web.HttpContext.Current.Items["MyScopedContext"] = new MyContext();
			}
			return (MyContext)System.Web.HttpContext.Current.Items["MyScopedContext"];
		}
