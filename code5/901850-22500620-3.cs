    public static class RequestExtensions
    {
        public static IRequest TraverseRequestChainAndFindMatch(this IRequest request, Func<IRequest, bool> matcher)
        {
            if (matcher(request))
            {
                return request;
            }
            if (request.ParentRequest != null)
            {
                return request.ParentRequest.TraverseRequestChainAndFindMatch(matcher);
            }
            return null;
        }
    }
