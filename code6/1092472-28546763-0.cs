         public class InvoiceProfile: Profile
            {
                protected override void Configure()
                {
                    Mapper.CreateMap<Invoice, InvoiceReportViewModel>()
                        .ForMember(c => c.CustomerName, op => op.MapFrom(v => v.CustomerName))
                        .ForMember(c => c.DiscountAmt, op => op.MapFrom(v => v.DiscountAmt))
                        .ForMember(c => c.InvoiceDate, op => op.MapFrom(v => v.InvoiceDate))
                        .ForMember(c => c.LineItems, op => op.MapFrom(v => v.InvoiceTransaction.TransactionItems));
        
                    Mapper.CreateMap<TransactionDetail, InvoiceReportLineItemViewModel>()
                        .ForMember(c => c.ProductName, op => op.MapFrom(v => v.Product.ProductName))
                        .ForMember(c => c.Qty, op => op.MapFrom(v => v.Qty))
    //and so on;
                }
            }
