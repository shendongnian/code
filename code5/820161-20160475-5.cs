    var handler = LicenseHandlerBuilder
            .CreateHandler((l, u) => l.IsEnabled && u.IsActive, Action1)
            .WithNext((l, u) => !l.IsEnabled && u.IsActive, Action2)
            .WithNext((l, u) => !l.IsEnabled && u.IsLocked, Action3)
            .Build();
