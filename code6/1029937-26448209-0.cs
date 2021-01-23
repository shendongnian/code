    [Initialize the variables]
    qtyPrd1 = 0;
    pricePrd1 = 0;
    
    qtyPrd2 = 0;
    pricePrd2 = 0;
    ...
    
    [Main loop]
    do {
    
    [Present the user the products]
    [Get the choice (product, quantity)]
    
    [Add the value to the product variable]
    if (choice == 1)
        qtyPrd1++;
    if (choice == 2)
        qtyPrd2++;
    subtotal = qtyPrd1 * pricePrd1 + qtyPrd1 * pricePrd2 + ...;
    [Present the subtotal]
    
    } while (result == DialogResult.Yes);
    
    [Compute total]
    total = qtyPrd1 * pricePrd1 + qtyPrd1 * pricePrd2 + ...;
    [Present total result of cart]
