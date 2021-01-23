    <system.serviceModel>
      <behaviors>
        <serviceBehaviors>
          <behavior>
            <serviceCredentials>
              <userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="CustomUsernamePasswordAuth.Service.UserNamePassValidator, CustomUsernamePasswordAuth.Service" />
            </serviceCredentials>
          </behavior>
        </serviceBehaviors>
      </behaviors>
    </system.serviceModel>
