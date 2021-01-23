        ContentModelSource1.ContentFilters.Add(new Ektron.Cms.Framework.UI.Controls.ContentFilter()
                {
                    Value = myContentIds, 
                    Operator = Ektron.Cms.Common.CriteriaFilterOperator.In, 
                    Field = Ektron.Cms.Common.ContentProperty.Id
                });
