    <microsoft.xrm.client>
      <contexts>
       <!-- Replace with your actual ServiceContext -->
       <add name="Xrm" type="Xrm.XrmServiceContext, Xrm" serviceName="Xrm" instanceMode="PerRequest"/>
      </contexts>
      <services>
       <!-- Disable cache -->
       <add name="Xrm" type="Microsoft.Xrm.Client.Services.OrganizationService, Microsoft.Xrm.Client"/>
      </services>
    </microsoft.xrm.client>
