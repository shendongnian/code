    public ProductInformation ExecuteQuery(int i)
    {
        thisProduct = new ProductInformation();
        switch (i)
            case 10:
                thisProduct = GiftCard();
                break;
            case 9:
                thisProduct = GiftCertificate();
                break;
        return thisProduct;
     }
