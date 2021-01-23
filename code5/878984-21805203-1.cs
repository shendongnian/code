    static void Main(string[] args)
            {
                // 1 query deep
                var def = new QueryDefinition();
                def
                    .AddField("Field1")
                    .AddField("Filed2")
                    .AddFieldWithSubQuery(subquery =>
                    {
                        subquery
                            .AddField("InnerField1")
                            .AddField("InnerFiled2")
                            .From("InnerTable")
                            .Where("<InnerCondition>");
                    })
                    .From("Table")
                    .Where("<Condition>");
    
    
                // 2 queries deep
                var def2 = new QueryDefinition();
                def
                    .AddField("Field1")
                    .AddField("Filed2")
                    .AddFieldWithSubQuery(subquery =>
                    {
                        subquery
                            .AddField("InnerField1")
                            .AddField("InnerField2")
                            .AddFieldWithSubQuery(subsubquery =>
                                {
                                    subsubquery
                                        .AddField("InnerInnerField1")
                                        .AddField("InnerInnerField2")
                                        .From("InnerInnerTable")
                                        .Where("<InnerInnerCondition>");
                                })
                            .From("InnerInnerTable")
                            .Where("<InnerCondition>");
                    })
                    .From("Table")
                    .Where("<Condition>");
            }
