    <profile defaultProvider="DefaultProfileProvider">
    	<providers>
    		<add name="DefaultProfileProvider" type="System.Web.Providers.DefaultProfileProvider, System.Web.Providers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" connectionStringName="YourConnectionStringName" applicationName="YourApplicationName" />
    	</providers>
    </profile>
    <membership defaultProvider="DefaultMembershipProvider">
    	<providers>
    		<add name="DefaultMembershipProvider" type="System.Web.Providers.DefaultMembershipProvider, System.Web.Providers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" connectionStringName="YourConnectionStringName" enablePasswordRetrieval="false" enablePasswordReset="true" requiresQuestionAndAnswer="false" requiresUniqueEmail="true" maxInvalidPasswordAttempts="10" minRequiredPasswordLength="0" minRequiredNonalphanumericCharacters="0" passwordAttemptWindow="10" applicationName="YourApplicationName" />
    	</providers>
    </membership>
    <roleManager enabled="true" defaultProvider="DefaultRoleProvider">
    	<providers>
    		<add name="DefaultRoleProvider" type="System.Web.Providers.DefaultRoleProvider, System.Web.Providers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" connectionStringName="YourConnectionStringName" applicationName="YourApplicationName" />
    	</providers>
    </roleManager>
