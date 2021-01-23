    // just sample data
    gridControl1.DataSource = new List<DataObj> { 
        new DataObj() { RValue = 0.2 }, 
        new DataObj() { RValue = 0.21 },  // !!! Orange
        new DataObj() { RValue = 0.201 }, // !!! Orange
        new DataObj() { RValue = 0.2001 },
        new DataObj() { RValue = 0.20001 },  
    };
    gridView1.PopulateColumns();
    //...
    var condExpression = new StyleFormatCondition(FormatConditionEnum.Expression);
    condExpression.Column = gridView1.Columns["RValue"];
    condExpression.Appearance.BackColor = Color.OrangeRed;
    condExpression.Appearance.Options.UseBackColor = true;
    condExpression.Expression = String.Format("Abs([RValue] - {0} - {1}) > {2}", 0.1, 0.1, EPSILON);
    gridView1.FormatConditions.Add(condExpression);
    //...
    class DataObj {
        public double RValue { get; set; }
    }
