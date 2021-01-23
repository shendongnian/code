	public class MultipleFilesXmlDocumentationProvider : IDocumentationProvider
	{
		IEnumerable<XmlDocumentationProvider> xmlDocumentationProviders;
		public MultipleFilesXmlDocumentationProvider(IEnumerable<string> documentPaths)
		{
			xmlDocumentationProviders = documentPaths.Select(path => new XmlDocumentationProvider(path));
		}
		public string GetDocumentation(HttpParameterDescriptor parameterDescriptor)
		{
			foreach(XmlDocumentationProvider provider in xmlDocumentationProviders)
			{
				string documentation = provider.GetDocumentation(parameterDescriptor);
				if(documentation != null)
					return documentation;
			}
			return null;
		}
		public string GetDocumentation(HttpActionDescriptor actionDescriptor)
		{
			foreach (XmlDocumentationProvider provider in xmlDocumentationProviders)
			{
				string documentation = provider.GetDocumentation(actionDescriptor);
				if (documentation != null)
					return documentation;
			}
			return null;
		}
		public string GetDocumentation(HttpControllerDescriptor controllerDescriptor)
		{
			foreach (XmlDocumentationProvider provider in xmlDocumentationProviders)
			{
				string documentation = provider.GetDocumentation(controllerDescriptor);
				if (documentation != null)
					return documentation;
			}
			return null;
		}
		public string GetResponseDocumentation(HttpActionDescriptor actionDescriptor)
		{
			foreach (XmlDocumentationProvider provider in xmlDocumentationProviders)
			{
				string documentation = provider.GetDocumentation(actionDescriptor);
				if (documentation != null)
					return documentation;
			}
			return null;
		}
	}
