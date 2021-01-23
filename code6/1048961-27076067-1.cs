        protected void CsSqlSelect(object s, GridItemEventArgs e)
        {
            GridEditableItem cmdItem = e.Item as GridEditableItem;
            RadComboBox cmbLst = (RadComboBox)cmdItem.FindControl("Cmb_Lst_Sel");
            if (cmbLst.CheckedItems.Count > 0)
            {
                var items = cmbLst.CheckedItems;
                string lst_ids = "";
                foreach (var item in items)
                {
                    lst_ids += "'" + item.Value + "'" + ",";
                }
                lst_ids = lst_ids.Remove(lst_ids.Length - 1);
            }
            // Once I have the list ids [lst_ids] from the RadComboBox [Cmb_Lst_Sel], 
            // I pass these IDs to SqlDataSource to filter and rebind the RadGrid [Grd_Url]
        }
