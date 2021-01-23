    //These are not default imports, so you need to use it
    using System.Text;
    using System.Security.Cryptography;
    
    //Before your actual class, you need to make your custom 512
    public class BillieJeansSHA512 : HMAC
    {
        public BillieJeansSHA512(byte[] key)
        {
            HashName = "System.Security.Cryptography.SHA512CryptoServiceProvider";
            HashSizeValue = 512;
            BlockSizeValue = 128;
            Key = (byte[])key.Clone();
        }
    }
    
    //Now, there's your actual class
    public class HelloWorld{
    
            
        //First, use this method to convert byte to String like a boss
        static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("x2"); /* hex format */
            return sbinary;
        }    
        
        //Now let's get it started!
        public static void Main(String []args){
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            
            //Your data
            var apiSecret = "5432919427bd18884fc2a6e48b65dfba48fd9a1a46e3468b52fadbc6d6b463425";
            var data = "payment_currency=USD&group_orders=0&count=100&nonce=1385689989977529";
            var endPoint = "/info/orderbook";
    
            String message = endPoint + Convert.ToChar(0) + data;
    
            //Hash will be stored here
            String hash = "";
    
            //put your key at your custom 512
            BillieJeansSHA512 hmacsha512 = new BillieJeansSHA512(encoding.GetBytes(apiSecret));
            //hash'em all
            byte[] result = hmacsha512.ComputeHash(encoding.GetBytes(message));
    
            //convert bytes to string
            hash = ByteToString(result);
    
            //See it :)
            Console.WriteLine(hash);
            
            //Or if you using it at a web-page, this is it.
            //Response.Write(hash)
            //Now the easy part, convert it to base64
            var bytesTo64 = System.Text.Encoding.UTF8.GetBytes(hash);
            String hash64 = System.Convert.ToBase64String(bytesTo64);
        }
    }
