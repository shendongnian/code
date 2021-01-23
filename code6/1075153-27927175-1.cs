    int len = result.GetBytes( 3, 0, null, 0, 0 );
    byte[] buf = new byte[len];
    result.GetBytes( 3, 0, buf, 0, buf.Length );
    model = new Model.CustomerProduct()
    {
        Product_Name = result.GetString(2),
        VIN = buf
    };
