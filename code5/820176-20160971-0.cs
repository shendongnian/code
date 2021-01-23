     if(lvwRentBook != null)
     {
        ListViewItem lvi = lvwRentBook.FindItemWithText(books.BookCode.ToString());
        // if it is null means, item does not exist.You can go ahead and add it.
        if (lvi == null)
        {
         lvi = new ListViewItem();
        
            lvi.Text = books.BookCode.ToString();
            lvi.SubItems.Add(books.BookDesc.ToString());
            lvi.SubItems.Add(books.SupplierCode.ToString());
            lvi.SubItems.Add(books.PricePurchase.ToString());
            lvi.SubItems.Add(txtRentPRice.Text.ToString());
            lvi.SubItems.Add(books.PricePenalty.ToString());
            lvi.SubItems.Add("1".ToString());
            lvi.SubItems.Add(books.Author.ToString());
            lvi.SubItems.Add(books.Category.ToString());
            lvi.SubItems.Add(books.Active.ToString());
            lvi.SubItems.Add(books.ModifiedBy.ToString());
            lvi.SubItems.Add(books.ModifiedOn.ToString());
            lvi.SubItems.Add(books.CreatedBy.ToString());
            lvi.SubItems.Add(books.CreatedOn.ToString());
            lvwRentBook.Items.Add(lvi);
        }
       }
