            Dictionary<string, object> ht =
                (Dictionary<string, object>)typeof( CryptoConfig ).InvokeMember( 
                "DefaultNameHT", System.Reflection.BindingFlags.GetProperty | 
                System.Reflection.BindingFlags.Static | 
                System.Reflection.BindingFlags.NonPublic, null, typeof( CryptoConfig ), 
                null );
            var o = ht["http://www.w3.org/2000/09/xmldsig#rsa-sha1"];
            ht["http://www.w3.org/2001/04/xmldsig-more#rsa-sha512"] = o;
