    public partial class MultiColumnSearchCombo : MultiColumnCombo
    {
           protected override void OnTextBoxTextChanged(EventArgs e)
           {
              GridEXFilterCondition internalFilter = new GridEXFilterCondition();
    
              String str = TextBox.Text;
              foreach (GridEXColumn column in DropDownList.Columns)
              {
                   if (!column.Visible)
                       continue;
    
                   GridEXFilterCondition filterCondition = new GridEXFilterCondition(column, ConditionOperator.Contains, str);
    
                   internalFilter.AddCondition(LogicalOperator.Or, filterCondition);
              }
        
              DropDownList.ApplyFilter(internalFilter);
        
           }
            
    }
