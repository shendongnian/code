            public void AddGridPanel()
            {
              Ext.Net.GridPanel g=new Ext.Net.GridPanel();
              Ext.Net.Store store1=new Ext.Net.Store();
              Model model = new Model();
              for (int i = 1; i < tas.getTaskDE().Count / 2; i++)
                    {
                        fields = fields + "," + tas.getTaskDE()[i].FieldName;
                        ModelField modelField = new ModelField();
                        modelField.Name = tas.getTaskDE()[i].FieldName;
                        model.Fields.Add(modelField);
    
                        if (tas.getTaskDE()[i].Visibility == "true")
                        {
                            g.ColumnModel.Columns.Add(new ColumnBase[] { 
                            new Column 
                              {
                                 Text = tas.getTaskDE()[i].FieldADName,
                                 DataIndex = tas.getTaskDE()[i].FieldName,
                                 Flex = 1
                              },
                             });
                        }
                    }
              SqlDataSource s = new SqlDataSource();
              s.ConnectionString =ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
              s.SelectCommand = query;
              store1.Model.Add(model);
              store1.DataSource = s;
              store1.DataBind();
              g.Store.Add(store1);
              g.Render(this.Form);
            }
