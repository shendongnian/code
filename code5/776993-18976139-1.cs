    Bind<Dictionary<Status, Image>>()
      .ToConstant(new Dictionary<Status, Image>()
                       {
                           {Status.New, new Image()},
                           {Status.Dropped, new Image()},
                           {Status.Approved, new Image()},
                       })
      .WhenInjectedInto<StatusHelper>();
