     The easiest way  to use a SiteMapProvider is  to configure with SecurityTrimmingEnabled = true.
     Add this under Web.Config file 
    <siteMap enabled="true" defaultProvider ="AspNetXmlSiteMapProvider" >
      <providers>
        <clear/>
        <add siteMapFile="Web.sitemap" name="AspNetXmlSiteMapProvider" type="System.Web.XmlSiteMapProvider" securityTrimmingEnabled="true" />
      </providers>
    </siteMap>
    try to add the roles to the site map like this
    <siteMapNode url="~/StaffRecords.aspx" title="Staff Records"  description=""     roles="StaffRole">
      <siteMapNode url="~/addStaff.aspx" title="Add new Staff" description="" />
    </siteMapNode>
