    QueryExpression qe = new QueryExpression
    {
    	EntityName = "serviceappointment",
    	Criteria = new FilterExpression
    	{
    		FilterOperator = LogicalOperator.And,
    		Conditions = 
    		{
    			new ConditionExpression
    			{
    				AttributeName = "scheduledstart", 
    				Operator = ConditionOperator.LessThan,
    				Values = 
    				{
    					endTime
    				}
    			},
    			new ConditionExpression
    			{
    				AttributeName = "scheduledend",
    				Operator = ConditionOperator.GreaterThan,
    				Values =
    				{
    					startTime
    				}
    			}
    		}
    	},
    	LinkEntities = 
    	{
    		new LinkEntity
    		{
    			LinkFromEntityName = "activitypointer",
    			LinkFromAttributeName = "activityid",
    			LinkToEntityName = "activityparty",
    			LinkToAttributeName = "activityid",
    			LinkCriteria = new FilterExpression
    			{
    				FilterOperator = LogicalOperator.And,
    				Conditions = 
    				{
    					new ConditionExpression
    					{
    						AttributeName = "partyid",
    						Operator = ConditionOperator.Equal,
    						Values = 
    						{
    							someEntity.id
    						}
    					}
    				}
    			}
    		}
    	}
    };
