            dgLatestPositions.DataSource = items;
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = items.GetType().Name;
            
            // Column 1
            DataGridTextBoxColumn tbcCoding= new DataGridTextBoxColumn();
            tbcCoding.Width = 100;
            tbcCoding.MappingName = "Coding";
            tbcCoding.HeaderText = "Coding";
            tableStyle.GridColumnStyles.Add(tbcCoding);
            
            // Column 2
            DataGridTextBoxColumn tbcAmount = new DataGridTextBoxColumn();
            tbcAmount .Width = 100;
            tbcAmount .MappingName = "Amount";
            tbcAmount .HeaderText = "Amount";
            tableStyle.GridColumnStyles.Add(tbcAmount );
            dgLatestPositions.TableStyles.Clear();
            dgLatestPositions.TableStyles.Add(tableStyle);
