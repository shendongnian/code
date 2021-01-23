    Session.CreateCriteria<Test>("test")
      .CreateAlias("test.Values", "values")
      // we add magic keyword ".elements" here
      .Add(Restrictions.Eq("values.elements", 10))
      .List();
