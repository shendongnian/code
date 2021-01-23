            List<Ticket> objTicket = new List<Ticket>();
            objTicket = ticketRepository.GetAllData().ToList();
            List<AccountType> ListAccounType = new List<AccountType>();
            ListAccounType = accountTypeRepository.GetAllData().ToList();
            List<AccountTransaction> ListAccount = new List<AccountTransaction>();
            ListAccount = accountTranastionRepository.GetAllData().ToList();
            List<AccountTransactionValue> ListAccountTransactionValue = new List<AccountTransactionValue>();
            ListAccountTransactionValue = accountTransactionValueRepository.GetAllData().ToList().Where(o => o.Date >= FromDate && o.Date <= ToDate).ToList();
            var ListAccountTransaction = from v in ListAccountTransactionValue
                                         join atr in objTicket on v.AccountTransactionId equals atr.Id
                                         join a in ListAccount on v.AccountId equals a.Id
                                         select new { v.Id, Name = a.Name, v.AccountTransactionId, VoucherNo = atr.Name.Substring(atr.Name.IndexOf("[")), AccountTransactionType = atr.Name.Substring(0, atr.Name.IndexOf("[")), atr.Date, SourceAccountTypeId = atr.Name, Description = atr.CompanyCode, DebitAmount = v.Debit, CreditAmount = v.Credit, atr.DepartmentId };
            var ListScreenTicketType = ListAccountTransaction.Select(o => new { o.Id }).Distinct().ToList();
            AccountTransactionDocument objAccountTransactionDocument = new AccountTransactionDocument();
            if (objAccountTransactionDocument != null)
            {
                AccountTransactionType objAccountTransactionType = new AccountTransactionType();
            }
            List<ScreenTicket> listScreenTicket = new List<ScreenTicket>();
            foreach (var accounttransaction in ListScreenTicketType)
            {
                var objaccounttransaction = ListAccountTransaction.Where(o => o.Id == accounttransaction.Id).FirstOrDefault();
                ScreenTicket objScreenTicket = new ScreenTicket();
                objScreenTicket.Id = accounttransaction.Id;
                objScreenTicket.Name = objaccounttransaction.Date.ToShortDateString();
                objScreenTicket.Note = objaccounttransaction.Name;
                var dataBytes = objaccounttransaction.Name;
                if (dataBytes != null)
                {
                    objScreenTicket.IsActive = true;
                }
                else
                {
                    objScreenTicket.IsActive = false;
                }
                var objscreens = ListAccountTransaction.Where(o => o.Name == objaccounttransaction.Name);
                List<PaymentHistory> listPaymentHistory = new List<PaymentHistory>();
                foreach (var screenvalue in objscreens)
                {
                    PaymentHistory objPaymentHistory = new PaymentHistory();
                    objPaymentHistory.Id = screenvalue.Id;
                    objPaymentHistory.AmountPaid = screenvalue.CreditAmount;
                    objPaymentHistory.Id = screenvalue.Id;
                    listPaymentHistory.Add(objPaymentHistory);
                }
                objScreenTicket.PaymentHistory = listPaymentHistory;
                listScreenTicket.Add(objScreenTicket);
            }
            return listScreenTicket;
        }
