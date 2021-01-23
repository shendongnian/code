     public IEnumerable PreparePayment(PXAdapter adapter)
        {
            List<ARRegister> doclist = new List<ARRegister>();
            SOOrderShipment soOrderShipment =
                         PXSelect
                             <SOOrderShipment,
                                 Where<SOOrderShipment.invoiceNbr, Equal<Required<SOOrderShipment.invoiceNbr>>>
                                 >.Select(new PXGraph(), Base.Document.Current.RefNbr);
            if (soOrderShipment != null)
            {
                SOOrder soOrder = PXSelect<SOOrder, Where<SOOrder.orderNbr,
                    Equal<Required<SOOrder.orderNbr>>,
                    And<SOOrder.orderType, Equal<Required<SOOrder.orderType>>>>>.Select(
                        new PXGraph(), soOrderShipment.OrderNbr, soOrderShipment.OrderType);
                SOOrderExt soExt = PXCache<SOOrder>.GetExtension<SOOrderExt>(soOrder);
                if (soExt.CustomerID != soExt.UsrARCustomer)
                {
                    BAccount bAccount = PXSelect<BAccount, Where<BAccount.bAccountID,Equal<Required<BAccount.bAccountID>>>>.Select(new PXGraph(),soExt.UsrARCustomer);
                    ARInvoiceEntry arInvoiceGraph = PXGraph.CreateInstance<ARInvoiceEntry>();
                    ARInvoice invoice = (ARInvoice)arInvoiceGraph.Caches[typeof(ARInvoice)].CreateInstance();
                    invoice = (ARInvoice) arInvoiceGraph.Caches[typeof (ARInvoice)].Insert(invoice);
                    // Using SetValueExt by Passing AcctCD
    arInvoiceGraph.Caches[typeof(ARInvoice)].SetValueExt<ARInvoice.customerID>(invoice,bAccount.AcctCD);
                    invoice.CustomerID = soExt.UsrARCustomer;
                    arInvoiceGraph.Caches[typeof(ARInvoice)].SetValue<ARInvoice.docDesc>(invoice, "N/A");
                    invoice.DocType = ARInvoiceType.DebitMemo;
                 
                    Location location =
                        PXSelect<Location, Where<Location.bAccountID, Equal<Required<Location.bAccountID>>>>.Select(
                            arInvoiceGraph, soExt.UsrARCustomer);
                    if(location!=null)
                           arInvoiceGraph.Caches[typeof(ARInvoice)].SetValue<ARInvoice.customerLocationID>(invoice, location.LocationID);
             
                    arInvoiceGraph.Caches[typeof(ARInvoice)].Update(invoice);
                    ARInvoice oldInvoice = (ARInvoice)arInvoiceGraph.Caches[typeof(ARInvoice)].CreateCopy(invoice);
                    invoice.CuryOrigDocAmt = Base.Document.Current.CuryOrigDocAmt;
                    arInvoiceGraph.Caches[typeof(ARInvoice)].RaiseRowUpdated(invoice, oldInvoice);
                    arInvoiceGraph.Caches[typeof(ARInvoice)].SetValue<ARInvoice.curyOrigDocAmt>(invoice, invoice.CuryDocBal);
                    arInvoiceGraph.Caches[typeof(ARInvoice)].SetValueExt<ARInvoice.hold>(invoice, false);
                    arInvoiceGraph.Caches[typeof(ARInvoice)].Update(invoice);
                    doclist.Add((ARInvoice)arInvoiceGraph.Caches[typeof(ARInvoice)].Current);
           // Insert transaction data
                    ARTran arTran = new ARTran();
                    arTran.TranDesc = "Total Value";
                    arTran.Qty = 1;
                    arTran.UnitPrice = Base.Document.Current.CuryDocBal;
                    arTran.CuryLineAmt = Base.Document.Current.CuryDocBal;
                    arInvoiceGraph.Transactions.Insert(arTran);
                    ARTran arTranUpdated = (ARTran) arInvoiceGraph.Transactions.Update(arTran);
                    arInvoiceGraph.Transactions.Current = arTranUpdated;
                    arInvoiceGraph.Transactions.Cache.Update(arInvoiceGraph.Transactions.Current);
                    arInvoiceGraph.Save.Press();
                }
            }
