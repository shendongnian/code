    foreach (var item in dir.GetFileSystemInfos().Where(item => item.IsVisible()))
				{
					if(item.IsDirectory())
					{
						visibleThings.Add(item);
					}else if(item.IsFile())
					{
						bool isXmlFile = item.Extension.ToLower().EndsWith("xml");
						if(isXmlFile)
						{
						visibleThings.Add(item);
						}
					}
				}
