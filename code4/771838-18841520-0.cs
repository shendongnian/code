    var r = new ModernDependencyResolver();
    (new ReactiveUI.Registrations()).Register((f,t) => r.Register(f, t));
    (new ReactiveUI.Cocoa.Registrations()).Register((f,t) => r.Register(f, t));
    (new ReactiveUI.Mobile.Registrations()).Register((f,t) => r.Register(f, t));
    RxApp.DependencyResolver = r;
    (new Akavache.Registrations()).Register(r.Register);
    (new Akavache.Mobile.Registrations()).Register(r.Register);
    (new Akavache.Sqlite3.Registrations()).Register(r.Register);
