    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DB_ClassDataContext Inv = new DB_ClassDataContext(conn))
            {
                var inventory = (from inv in Inv.Inventories
                                where inv.ItemNumber == DropDownList2.Text
                                select new
                                {
                                    itemName = inv.ItemName,
                                    itemDesc = inv.ItemDesc,
                                    itemPrice = inv.ItemPrice
                                }).First();
                var itemname = inventory.itemName;
                var itemdesc = inventory.itemDesc;
                var itemprice = inventory.itemPrice;
                txtItemName.Text = itemname;
                txtItemDesc.Text = itemdesc;
                txtItemPrice.Text = itemprice.ToString();
               
            }
            
        }
