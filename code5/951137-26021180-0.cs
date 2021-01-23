    public override void Validate(ServiceEndpoint endpoint)
    {
        base.Validate(endpoint);
		//TODO: Stop throwing exception for default behavior.
        //BindingElementCollection elements = endpoint.Binding.CreateBindingElements();
        //WebMessageEncodingBindingElement webEncoder = elements.Find<WebMessageEncodingBindingElement>();
        //if (webEncoder == null)
        //{
        //    throw new InvalidOperationException("This behavior must be used in an endpoint with the WebHttpBinding (or a custom binding with the WebMessageEncodingBindingElement).");
        //}
        //foreach (OperationDescription operation in endpoint.Contract.Operations)
        //{
        //    this.ValidateOperation(operation);
        //}
    }
