      <system.serviceModel>
        <behaviors>
          <serviceBehaviors>
            <behavior name="MyBehavior">
              <serviceMetadata httpGetEnabled="true" externalMetadataLocation="../ContractMetaData/RestaurantService.wsdl"/>
            </behavior>
          </serviceBehaviors>
        </behaviors>
        ...
        <services>
          <service name="RestaurantService.RestaurantService" behaviorConfiguration="MyBehavior">
            ...
          </service>
        </services>
      </system.serviceModel>
