        private static string FormatStringAsBase64(string message_encrypted_base64)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message_encrypted_base64.Length; i++)
            {
                //current char
                char currchar = message_encrypted_base64[i];
                //check if we got a valid base64 symbol
                /* From Microsoft MSDN Official Convert.ToBase64String Method (http://msdn.microsoft.com/en-us/library/dhx0d524.aspx):
                 * The base-64 digits in ascending order from zero are the uppercase 
                 * characters "A" to "Z", the lowercase characters "a" to "z", the numerals "0" 
                 * to "9", and the symbols "+" and "/". 
                 * The valueless character, "=", 
                 * is used for trailing padding.
                 * 
                 */
                if (char.IsLetterOrDigit(currchar) || currchar == '=' || currchar == '+' || currchar == '/')
                {
                    sb.Append(currchar);
                }
            }
            return sb.ToString();
        }
