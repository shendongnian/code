    public MyConvetion : IPropertyConventionAcceptance 
    {
      public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
      {
        criteria.Expect(x => boolValue); // [is there a IgnoreAttribute]);
      }
    }
