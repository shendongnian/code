    private static string Decrypt(string webResourceParameter)
        {
            var purposeType = Type.GetType("System.Web.Security.Cryptography.Purpose, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            if (purposeType == null)
                return null;
            try
            {
                var purpose = Activator.CreateInstance(purposeType, "AssemblyResourceLoader.WebResourceUrl");
                const BindingFlags decryptFlags = BindingFlags.NonPublic | BindingFlags.Static;
                var decryptString = typeof (Page).GetMethod("DecryptString", decryptFlags);
                var decrypt = decryptString.Invoke(null, new[] {webResourceParameter, purpose}) as string;
                return decrypt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
