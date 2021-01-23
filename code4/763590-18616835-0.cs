    db.ApplicationMappingFulls.Select(m => new ApplicationMappingViewModel
        {
            SomeProperty = m.SomeProperty,
            OtherProperty = m.OtherProperty
        });
