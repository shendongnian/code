    public bool IsCustomUflPresent 
    { 
      get
      {
        return this.DataDefinition.FormulaFields.Cast().Any(x => x.Text.Contains("CustomUfl("));
      }
    }
