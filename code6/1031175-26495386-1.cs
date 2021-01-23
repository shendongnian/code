    protected void gridOver_ItemCreated(object sender, GridItemEventArgs e)
    {
       if (e.Item is GridDataItem)
       {
           // ... declare and init x somehow    
           foreach (GridColumn col in gridOver.MasterTableView.RenderColumns)
           {
               if (col.UniqueName == "rejected")
               {
                  GridDataItem dataItem = (GridDataItem)e.Item;
                  LinkButton btn = new LinkButton();
                  btn.ID = dataItem.Cells[2].Text + "-" + x.ToString();
                  btn.Text = dataItem[col.UniqueName].Text;
                  btn.ForeColor = System.Drawing.Color.Black;                                    
                  btn.Click += gridOver_Click;
                  dataItem[col.UniqueName].Controls.Add(btn);
                  x++;
               }
            }
        }
    }
