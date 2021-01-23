    [HttpGet]
        public ActionResult Transaction_Read([DataSourceRequest] DataSourceRequest request, string AccountID, DateTime StatementDate)
        {
            //var loginName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\');
            //var username = loginName.Last() + "@xxxx.com";
            var username = "xxxx@xxxx.com";
            var stmtDate = StatementDate;
            var q = from b in db.CorpCardTransactions
                    where b.Username == username && b.StatementDate == StatementDate && b.AccountID == AccountID && !b.SubmitDate.HasValue
                    select b;            
            return Json(q.ToList().ToDataSourceResult(request));
        }
