    post.AddBody(new {
        name = testname,
        variations = new object[] {
            new {
                name = "Small",
                pricing_type = "FIXED_PRICING",
                price_money = new {
                    currency_code = "USD",
                    amount = 400
                }
            }
        },
        sku = "123"
    });
