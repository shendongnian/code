    using System;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace WPA2MasterKeyGeneRator
    {
        public class WpaKeyCalculator
        {
            static void Main()
            {
                var keyCalculator = new WpaKeyCalculator("dlink");
    
                var key = keyCalculator.GetWpaMasterKey("1234567");
    
                //print hex
                //you can check results using online calculator here http://jorisvr.nl/wpapsk.html
                Console.WriteLine(BitConverter.ToString(key).Replace("-", ""));
            }
    
            private readonly byte[] _ssidBytes;
    
            public WpaKeyCalculator(string ssidName)
            {
                _ssidBytes = Encoding.ASCII.GetBytes(ssidName);
            }
    
            private byte[] GetWpaMasterKey(string password)
            {
                Rfc2898DeriveBytes pbkdf2;
    
                //little magic here
                //Rfc2898DeriveBytes class has restriction of salt size to >= 8
                //but rfc2898 not (see http://www.ietf.org/rfc/rfc2898.txt)
                //we use Reflection to setup private field to avoid this restriction
    
                if (_ssidBytes.Length >= 8)
                    pbkdf2 = new Rfc2898DeriveBytes(password, _ssidBytes, 4096);
                else
                {
                    //use dummy salt here, we replace it later vie reflection
                    pbkdf2 = new Rfc2898DeriveBytes(password, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 4096);
    
                    var saltField = typeof(Rfc2898DeriveBytes).GetField("m_salt", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                    saltField.SetValue(pbkdf2, _ssidBytes);
                }
    
                //get 256 bit PMK key
                return pbkdf2.GetBytes(32);
            }
        }
    }
