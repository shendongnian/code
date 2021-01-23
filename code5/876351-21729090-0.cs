    string line = "92.44.12.5/28";
    string[] ip1 = line.Split('.');
    int[] ipArray = Array.ConvertAll(ip1, new Converter<string, int>(StringToInt));
     public static int StringToInt(string value)
            {
                value = value.Contains('/') ? value.Split('/')[0] : value;  
                int result = 0;
                    int.TryParse(value, out result);
                return result;
            }
