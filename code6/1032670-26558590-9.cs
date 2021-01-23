	// Set a key explicitly to attach the dynamic nodes to. 
	// The key property here corresponds to the ParentKey property of the dynamic node.
	<mvcSiteMapNode title="Home" controller="Home" action="Index" key="Home">
		// Use a "dummy" node for each dynamic node provider. This node won't be in the SiteMap.
		<mvcSiteMapNode dynamicNodeProvider="NamespaceName.SomeDynamicNodeProivder, AssemblyName"/>
	</mvcSiteMapNode>
