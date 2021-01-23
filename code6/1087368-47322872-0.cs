    QueryExpression query = new QueryExpression(LetterEntityAttributeNames.EntityName)
                    {
                        ColumnSet = new ColumnSet(new string[]
                            {
                                LetterEntityAttributeNames.SubjectFieldName,
                                LetterEntityAttributeNames.RegardingObjectId,
                                LetterEntityAttributeNames.ToFieldName
                            }),
                        Criteria = new FilterExpression
                        {
                            FilterOperator = LogicalOperator.And,
                            Conditions =
                                {
                                    new ConditionExpression
                                    {
                                        AttributeName = LetterEntityAttributeNames.DirectChannelTypeFieldName,
                                        Operator = ConditionOperator.Equal,
                                        Values =
                                        {
                                            DirectChannelType
                                        }
                                    },
                                    new ConditionExpression
                                    {
                                        AttributeName = LetterEntityAttributeNames.RegardingObjectId,
                                        Operator = ConditionOperator.Equal,
                                        Values =
                                        {
                                            RegardingId
                                        }
                                    }
                                }
                        },
                        LinkEntities =
                            {
                                new LinkEntity
                                {
                                    LinkFromEntityName = ActivityPointerEntityAttributeNames.EntityName,
                                    LinkFromAttributeName = ActivityPartyAttributeNames.ActivityId,
                                    LinkToEntityName = ActivityPartyAttributeNames.EntityName,
                                    LinkToAttributeName = CampaignActivityAttributeNames.Id,
                                    LinkCriteria = new FilterExpression
                                    {
                                        FilterOperator = LogicalOperator.And,
                                        Conditions =
                                        {
                                            new ConditionExpression
                                            {
                                                AttributeName = ActivityPointerAttributeNames.PartyIdField,
                                                Operator = ConditionOperator.Equal,
                                                Values =
                                                {
                                                    ToEntityGuid
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                    };
