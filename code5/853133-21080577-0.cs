    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.SharePoint.Publishing;
    using Microsoft.SharePoint.Publishing.Navigation;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Configuration;
    
    namespace MyCustomNav
    {
    public class Navigation: PortalSiteMapProvider
    {
    public override SiteMapNodeCollection GetChildNodes(System.Web.SiteMapNode 
    node)
    {
    PortalSiteMapNode pNode = node as PortalSiteMapNode;
    if (pNode != null)
    {
    if (pNode.Type == NodeTypes.Area)
    {
    SiteMapNodeCollection nodeColl = base.GetChildNodes(pNode);
    SiteMapNode childNode = new SiteMapNode(this, 
    "<http://www.microsoft.com>", "<http://www.microsoft.com>", "Microsoft");
    
    SiteMapNode childNode1 = new SiteMapNode(this, 
    "<http://support.microsoft.com>", "<http://support.microsoft.com>", "Support");
    
    nodeColl.Add(childNode);
    
    SiteMapNodeCollection test = new SiteMapNodeCollection();
    test.Add(childNode1);
    childNode.ChildNodes = test;
    
    return nodeColl;
    }
    else
    return base.GetChildNodes(pNode);
    }
    else
    return new SiteMapNodeCollection();
    }
    }
    }
