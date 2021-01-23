            [Test]
            public void AreMappingsValid()
            {
                ConfigureAutomapper.Configure();
                AutoMapper.Mapper.AssertConfigurationIsValid();
            }
