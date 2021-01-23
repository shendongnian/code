        public override void DataBind()
        {
            if (AuditGridView.Columns.Count == 0)
                foreach (var pair in LAudit.Properties)
                {
                    AuditGridView.Columns.Add(new BoundField
                                              {
                                                  DataField = pair.Key,
                                                  HeaderText = pair.Value,
                                                  SortExpression = pair.Key
                                              });
                }
            base.DataBind();
        }
