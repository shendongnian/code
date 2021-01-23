          GridEXFilterCondition internalFilter = new GridEXFilterCondition();
          foreach (GridEXColumn column in DropDownList.Columns)
          {
               if (!column.Visible)
                   continue;
               GridEXFilterCondition filterCondition = new GridEXFilterCondition(column, ConditionOperator.Contains, str);
               internalFilter.AddCondition(LogicalOperator.Or, filterCondition);
          }
    
          DropDownList.ApplyFilter(internalFilter);
