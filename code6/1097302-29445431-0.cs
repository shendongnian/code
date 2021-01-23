    using (var mock = AutoMock.GetLoose())
    {
        mock.Container.ComponentRegistry.Register(
            RegistrationBuilder
                .ForType<MyClass>()
                .PropertiesAutowired()
                .CreateRegistration<MyClass, ConcreteReflectionActivatorData, SingleRegistrationStyle>()
        );
    }
