        private string GetPostCode(string address )
        {
            string result = string.Empty;
            string[] list = address.Split(',');
            list.Reverse();
            foreach (var item in list)
            {
                // if item contains numeric postcode 
                Regex re = new Regex(@"\d+");
                Match m = re.Match(item);
                result = m.Value;
                if (!string.IsNullOrEmpty(result))
                    break;
            }
            return result;
        }
