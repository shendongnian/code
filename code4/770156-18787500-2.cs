    var query = (from b in doc.WireLine_Movements 
                         where b.CustomerInvoiceNo.Contains(txtCustomerInvoiceNo.Text.Trim())
                         orderby b.ID descending
                         select new { b.AssetCode, b.CustomerInvoiceNo, b.CurrentLocation,
                                      b.FromLocation}).Take(1).ToList();
