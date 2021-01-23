    GridView gvForCheckBox = (GridView)e.Item.FindControl("gvProduct") as GridView;
                        foreach (GridViewRow gr in gvForCheckBox.Rows)
                        {
    
    int rowIndex = gr.RowIndex;
    string val = (string)this.gvForCheckBox .DataKeys[rowIndex]["myKey"];
                            //If product name of items in prodList and SPUItemList matches
                            if (available.Where(x => x.id == val ).Any())
                            {
                                //Mark the checkBox checked
                                CheckBox cb = (CheckBox)gr.Cells[0].FindControl("cbCheckRow");
                                cb.Checked = true;
    
                                //Get the product packaging quantity by productName
                                string name = gr.Cells[1].Text;
                                int productQuantity = packBLL.getProductQuantityByName(name);
                                TextBox tb = (TextBox)gr.Cells[3].FindControl("tbQuantity");
                                tb.Text = productQuantity.ToString();
                            }
                        }
