    [SoapDocumentMethod( "&&&", RequestElementName = "SubscriptionQueryRequest", RequestNamespace = "&&&", ResponseNamespace = "&&&", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped )]
    [return: XmlAnyElement]
    public List<XmlNode> SubscriptionQuery(string SubscriberId, int SortType, bool SortDescending, string Service, string ReferenceID, string SubscriptionName, int StartingSequence, int ResultCount )
    {
        object[] results = this.Invoke( "SubscriptionQuery", new object[] {
                SubscriberId, 
                SortType, 
                SortDescending,
                Service,
                ReferenceID,
                SubscriptionName, 
                StartingSequence,
                ResultCount
        } );
        return ( (List<XmlNode>)( results[0] ) );
    }
