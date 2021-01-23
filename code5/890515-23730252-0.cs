     <behaviors>
          <serviceBehaviors>
            <behavior name="customServiceBehaviour">
              <serviceAuthorization principalPermissionMode="Custom" >
                <authorizationPolicies>
                  <add policyType="Services.Host.CustomRolesPolicy, Services.Host" />
                </authorizationPolicies>            
              </serviceAuthorization>
            </behavior>            
          </serviceBehaviors>
      </behaviors>
