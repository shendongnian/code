    Expression<Func<Source, Subtype>> innerExpression = x => new Subtype {
        Subfield1 = x.SomeField;
        Subfield2 = x.SomeOtherField;
    }
    
    Expression<Func<Source, Target>> secondExpression = x => new Target {
        Field1 = x.Other1,
        Field2 = x.Other2,
        Field3 = x.Items.Where(y => y.Field == true).SingleOrDefault(),
        Field4 = innerExpression.Invoke(x)
    }
    Expression<Func<Source, Target>> finalExpression = secondExpression.Expand();
