    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TransactionPage transaction = (TransactionPage)e.Item.DataItem;
                TransactionPagePartial visual = (TransactionPagePartial)Page.LoadControl("~/Views/Pages/Partials/TransactionPagePartial.ascx");
                visual.transaction = transaction;
                rptTransactionVisual.Controls.Add(tombstone);
            }
