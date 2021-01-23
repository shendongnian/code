    protected void rdg_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;
                string str = editedItem.GetDataKeyValue("TransazioneID").ToString();
                TextBox1.Text = str ;
            }
        }
