            private bool IsPostCode(string text)
            {
                var nospace = text.Replace(" ", string.Empty);
                if (nospace.Length < 6)
                {
                    return false;
                }
    
                char[] chars = text.ToCharArray();
    
                if (chars[0] < 'A' || chars[0] > 'Z')
                {
                    return false;
                }
    
                if (chars[1] < 'A' || chars[1] > 'Z')
                {
                    return false;
                }
    
                if (chars[2] < '0' || chars[2] > '9')
                {
                    return false;
                }
    
                return true;
            }
