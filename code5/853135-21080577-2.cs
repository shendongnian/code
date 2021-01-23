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
