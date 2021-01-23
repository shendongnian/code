    public Order(string orderReference,
    			 string userEmail,
    			 string paymentIssuer,
    			 bool? isProcessed,
    			 ICollection<OrderDetail> orderDetails)
    {
    	OrderReference = orderReference;
    	UserEmail = userEmail;
    	PaymentIssuer = paymentIssuer;
    	IsProcessed = isProcessed;
    	OrderDetails = orderDetails;
    }
