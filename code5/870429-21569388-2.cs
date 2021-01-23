    internal class OfferSpecification : IRequestSpecification
    {
        public bool IsSatisfiedBy(object request)
        {
            var requestType = request as Type;
            if (requestType == null)
                return false;
            return typeof(Offer).IsAssignableFrom(requestType);
        }
    }
