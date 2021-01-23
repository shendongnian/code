    public class LbWsdl : IWsdlExportExtension, IEndpointBehavior
    {
        public void ExportContract(WsdlExporter exporter, WsdlContractConversionContext context)
        {
            // Fix WSDL here
        }
    }
    public class LbWsdlExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(LbWsdl); }
        }
    }
    <system.serviceModel>
      <extensions>
        <behaviorExtensions>
          <add name="lbWsdl" type="LbWsdlExtensions.LbWsdlExtension,LbWsdlExtension />
        </behaviorExtensions>
      </extensions>
      <behaviors>
        <endpointBehaviors>
          <behavior name="LoadBalancedBehavior">
            <webHttp/>
            <lbWsdl />
          </behavior>
        </endpointBehaviors>
      </behaviors>
    </system.serviceModel>
