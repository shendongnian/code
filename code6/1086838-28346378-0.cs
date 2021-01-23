            IEnumerable<StockVendorHistoryModal> vendorhistoryList = Session.Query<PurchaseOrderLineItem>()
                .Where(popredicate)
                .Where(p => p.Stock.Number != null)
                .Select(c => new StockVendorHistoryModal
                {
                    StockId = c.Stock.Id,
                    LastPurchaseDate = c.PurchaseOrder == null ? null : c.PurchaseOrder.OrderDate.ToString("yyyy/MM/dd"),
                    VendorNumber =   c.PurchaseOrder == null ? string.Empty : c.PurchaseOrder.PurchaseOrderVendor.Vendor.Number,
                    VendorName = c.PurchaseOrder == null ? string.Empty : c.PurchaseOrder.PurchaseOrderVendor.Vendor.Name,
                    LastPurchasePrice = c.UnitPrice,
                    LastTransactionDate = c.LastTransactionDate != null ? c.LastTransactionDate.Value.ToString("yyyy/MM/dd") : null,
                    LeadTimeDays = GetDays(c.PurchaseOrder.OrderDate, c.LastTransactionDate),
                }).GroupBy(d => d.VendorNumber)
                .SelectMany(gpo => gpo.OrderByDescending(x => x.LastPurchaseDate).Take(4)); 
