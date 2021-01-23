    [
      uuid(E66DC08B-A63A-41A8-B63D-15ED6F4569AB),
      version(1.0),
    ]
    library ClassLibrary1
    {
        interface _Class1;
    
        [
          uuid(9F2B6958-742F-4E5D-A5F3-D6BDC6C841DB),
          version(1.0),
        ]
        coclass Class1 {
            [default] interface _Class1;
            interface _Object;
        };
    
        [
          odl,
          uuid(F56AF0FC-D93B-399E-8FBD-9B72CF50D7D9),
          hidden,
          dual,
          oleautomation,
        ]
        interface _Class1 : IDispatch {
        };
    };
