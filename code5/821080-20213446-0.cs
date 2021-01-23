    List<Expression<Func<TransactionLog, bool>>> predicates = new List<Expression<Func<TransactionLog, bool>>>();
            iThNkContextDataContext db = new iThNkContextDataContext();
            if (Convert.ToInt32(cboAccount.SelectedValue) != -1)
            {
                predicates.Add(p => p.AccountID == Convert.ToInt32(cboAccount.SelectedValue));
            }
            if (Convert.ToInt32(cboSite.SelectedValue) != -1)
            {
                predicates.Add(p => p.SiteID == Convert.ToInt32(cboSite.SelectedValue));
            }
            if (Convert.ToInt32(cboMessage.SelectedValue) != -1)
            {
                predicates.Add(p => p.TransactionMessageID == Convert.ToInt32(cboMessage.SelectedValue));
            }
            var result = db.TransactionLogs.AsQueryable();
            foreach (Expression<Func<TransactionLog, bool>> pred in predicates)
            {
                result = result.Where(pred);
            }
            rgLog.DataSource = result.ToList();
