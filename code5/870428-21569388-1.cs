    internal class OfferFiller : ISpecimenCommand
    {
        public void Execute(object specimen, ISpecimenContext context)
        {
            if (specimen == null)
                throw new ArgumentNullException("specimen");
            if (context == null)
                throw new ArgumentNullException("context");
            var offer = specimen as Offer;
            if (offer == null)
                throw new ArgumentException(
                    "The specimen must be an instance of Offer.",
                    "specimen");
            Array.ForEach(offer.GetType().GetProperties(), x =>
            {
                if (x.Name == "CompanyHistory ")
                    x.SetValue(offer, /*value*/);
                else 
                    x.SetValue(offer, context.Resolve(x.PropertyType));
            });
        }
    }
