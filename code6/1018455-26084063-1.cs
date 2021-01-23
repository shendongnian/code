      public void initDatagrid()
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "رقم المتسلسل" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "رقم الحساب" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "أسم الحساب" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "المالك" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "تاريخ" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "قيمة" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "نوع العملة" });
                //...
            } 
