    public class AddressConverter : ITypeConverter<OrderAddress, object>
    {
        public object Convert(ResolutionContext context)
        {
            var o = context.SourceValue as OrderAddress;
            if (o == null) return null;
            if (o.addressType == "Delivery") return Mapper.Map<OR.DeliveryAddress>(o);
            if (o.addressType == "Invoice") return Mapper.Map<OR.InvoiceAddress>(o);
            return null;
        }
    }
