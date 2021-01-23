     private void gridCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridCustomer.Rows[e.RowIndex];
                var selectedItme = row.Cells["Id"].Value;
                var objOrder = orderBusiness.OrderFindById(Convert.ToInt32(selectedItme));
                /* Add This */
                BindingList<Order> bl = new BindingList<Order> { objOrder };                
                gridOrder.DataSource = bl;
                
            }
        }
