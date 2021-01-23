    namespace ClassLibrary1
    {
    	class ThatClass
    	{
    		public static string RequestCode(string countryCode, string phoneNumber, out string password, string method = "sms", string id = null, string language = null, string locale = null, string mcc = "204", string salt = "") { password = ""; return ""; }
    		public static string RequestCode(string countryCode, string phoneNumber, out string password, out string response, string method = "sms", string id = null, string language = null, string locale = null, string mcc = "204", string salt = "") { password = "";  response = ""; return ""; }
    		public static string RequestCode(string countryCode, string phoneNumber, out string password, out string request, out string response, string method = "sms", string id = null, string language = null, string locale = null, string mcc = "204", string salt = "") { password = ""; response = ""; request = ""; return ""; }
    	}
    }
