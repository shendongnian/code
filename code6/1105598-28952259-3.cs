    // Create the payment
    var payment = new Payment
    {
        intent = "sale",
        experience_profile_id = createdProfile.id,
        payer = new Payer
        {
            payment_method = "paypal"
        },
        transactions = new List<Transaction>
        {
            new Transaction
            {
                description = "Ticket information.",
                item_list = new ItemList
                {
                    items = new List<Item>
                    {
                        new Item
                        {
                            name = "Concert ticket",
                            currency = "USD",
                            price = "20.00",
                            quantity = "2",
                            sku = "ticket_sku"
                        }
                    }
                },
                amount = new Amount
                {
                    currency = "USD",
                    total = "45.00",
                    details = new Details
                    {
                        tax = "5.00",
                        subtotal = "40.00"
                    }
                }
            }
        },
        redirect_urls = new RedirectUrls
        {
            return_url = "http://www.somesite.com/order.aspx?return=true",
            cancel_url = "http://www.somesite.com/order.aspx?cancel=true"
        }
    };
    
    var createdPayment = payment.Create(apiContext);
