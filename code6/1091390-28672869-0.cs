    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
      <sectionExtension type="Unity.FactoryConfig.FactoryConfigExtension, Unity.FactoryConfig"/>
      <alias alias="Factory" type="Namespace.Factory, Assembly"/>
      <container>
        <register type="NameSpace.FactoryCreated, Assembly">
          <factory type="Factory" method="Create"/>
        </register>
      </container>
    </unity>
