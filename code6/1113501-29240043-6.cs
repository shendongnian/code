    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                UserInfo user = new UserInfo
                {
                    UserName = "jschmoe",
                    UserPassword = "Hunter2",
                    FavoriteColor = "atomic tangerine",
                    CreditCardNumber = "1234567898765432",
                };
                // Note: in production code you should not hardcode the encryption
                // key into the application-- instead, consider using the Data Protection 
                // API (DPAPI) to store the key.  .Net provides access to this API via
                // the ProtectedData class.
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Formatting = Formatting.Indented;
                settings.ContractResolver = new EncryptedStringPropertyResolver("My-Sup3r-Secr3t-Key");
                Console.WriteLine("----- Serialize -----");
                string json = JsonConvert.SerializeObject(user, settings);
                Console.WriteLine(json);
                Console.WriteLine();
                Console.WriteLine("----- Deserialize -----");
                UserInfo user2 = JsonConvert.DeserializeObject<UserInfo>(json, settings);
                Console.WriteLine("UserName: " + user2.UserName);
                Console.WriteLine("UserPassword: " + user2.UserPassword);
                Console.WriteLine("FavoriteColor: " + user2.FavoriteColor);
                Console.WriteLine("CreditCardNumber: " + user2.CreditCardNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }
        }
    }
 
