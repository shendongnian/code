    <membership defaultProvider="OracleMembershipProvider">
      <providers>
        <clear />
        <add name="OracleMembershipProvider" type="Oracle.Web.Security.OracleMembershipProvider, Oracle.Web, Version=4.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342" connectionStringName="OraAspNetConnectionString" applicationName="YOUR_APP_NAME" enablePasswordRetrieval="false" enablePasswordReset="true" requiresQuestionAndAnswer="false" requiresUniqueEmail="false" passwordFormat="Hashed" maxInvalidPasswordAttempts="5" minRequiredPasswordLength="5" minRequiredNonalphanumericCharacters="0" passwordAttemptWindow="10" passwordStrengthRegularExpression="" />
      </providers>
    </membership>
    <profile>
      <providers>
        <clear />
        <add name="OracleProfileProvider" type="Oracle.Web.Profile.OracleProfileProvider, Oracle.Web, Version=4.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342" connectionStringName="OraAspNetConnectionString" applicationName="YOUR_APP_NAME" />
      </providers>
    </profile>
    <roleManager enabled="true" defaultProvider="OracleRoleProvider">
      <providers>
        <clear />
        <add connectionStringName="OraAspNetConnectionString" applicationName="YOUR_APP_NAME" name="OracleRoleProvider" type="Oracle.Web.Security.OracleRoleProvider, Oracle.Web, Version=4.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342" />
      </providers>
    </roleManager>
