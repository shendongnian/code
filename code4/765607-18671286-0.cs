    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
      </configSections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <assembly name="Biblioteca" />
        <assembly name="Biblioteca.Contracts" />
        <assembly name="Biblioteca.Business" />
        <namespace name="Biblioteca" />
        <namespace name="Biblioteca.Contracts" />
        <namespace name="Biblioteca.Business" />
        <container>
          <register type="IManterCategoriaBO" mapTo="ManterCategoriaBO" />
          <!-- Or this works -->
          <!--<register type="Biblioteca.Contracts.IManterCategoriaBO, Biblioteca" mapTo="Biblioteca.Business.ManterCategoriaBO, Biblioteca" />-->
        </container>
      </unity>
    </configuration>
