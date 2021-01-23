    using System.Security.Cryptography;
    
    public static Stream EncodeStreamUsingBase64( Stream input )
    {
        if( input == null ) throw new ArgumentNullException( nameof(input) );
        ICryptoTransform xf = new ToBase64Transform();
        return new CryptoStream( input, xf, CryptoStreamMode.Write, leaveOpen: false );
    }
