    ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition", ConditionTypes.Greater, "30", "", false);
    obj.CellBackColor = Color.SkyBlue;
    obj.CellForeColor = Color.Red;
    obj.TextAlignment = ContentAlignment.MiddleRight;
    this.radGridView1.Columns["UnitPrice"].ConditionalFormattingObjectList.Add(obj);
