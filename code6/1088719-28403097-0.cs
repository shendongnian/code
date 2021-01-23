    QueryExpression query = new QueryExpression
    {
        EntityName = "contact",
        ColumnSet = new ColumnSet("fullname", "ht_customer_num", "ht_is_customer"),
        Criteria = new FilterExpression
        {
            Conditions = 
            {
                new ConditionExpression
                {
                    AttributeName = "new_is_customer",
                    Operator = ConditionOperator.Equal,
                    Values = { true }
                },
            },
        }
    };
