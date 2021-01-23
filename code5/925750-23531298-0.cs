    config.CreateMap<UrlPickerState, Link>()
				.ConvertUsing(arg =>
				{
					if (string.IsNullOrWhiteSpace(arg.Url))
					{
						return null;
					}
					return new Link()
					{
						Url = arg.Url,
						OpenInNewWindow = arg.NewWindow,
						Title = arg.Title,
					};
				});
