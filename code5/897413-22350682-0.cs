        <serviceBehaviors>
          <behavior name="CustomValidator">
            <serviceCredentials>
              <userNameAuthentication
                userNamePasswordValidationMode="Custom"
                customUserNamePasswordValidatorType=
     "SomeAssembly.MyCustomUserNameValidator, SomeAssembly"/>
            </serviceCredentials>
          </behavior>
        </serviceBehaviors>
