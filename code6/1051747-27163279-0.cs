        private void GrandTotal()
        {
         float GTotal = 0f;
         for (int i = 0; i < GridView1.Rows.Count; i++)
         {
            String total = (GridView1.Rows[i].FindControl("lblTotal") as Label).Text;
            GTotal += Convert.ToSingle(total);
         }
         txtTotal.text=GTotal.toString();
        }
