    public class MyController : Controller
    {
        private static string m_oneTimeKey = "this key hasn't been initialised yet";
        private string oneTimeKeyGet()
        {
            // Return the last key
            string returnValue = MyController.m_oneTimeKey;
            // Generate a new random key so the one we return can't be reused
            var m_oneTimeKey = GetRandomString();
            return returnValue;
        }
        private string oneTimeKeySet()
        {
            // Generate a new random key
            var newValue = GetRandomString();
            m_oneTimeKey = newValue;
            return newValue;
        }
        private string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var returnValue = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return returnValue;
        }
