    <modules runAllManagedModulesForAllRequests="true">
      <remove name="FormsAuthenticationModule" />
      <!--WIF 4.5 modules -->
      <add name="SessionAuthenticationModule" type="System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
    
      <!-- Adding the below causes a "ID0006: The input string parameter is either null or empty. Parameter name: Issuer" error -->
      <!--<add name="WsFederationAuthenticationModule" type="System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>-->
    </modules>
