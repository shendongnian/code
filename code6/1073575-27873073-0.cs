        private string GetPostCode(string address )
        {
            string result = string.Empty;
            string[] list = address.Split(',');
            list.Reverse();
            foreach (var item in list)
            {
                // if item contains numeric postcode 
                result = item; // extract postcode from state or city and take it as result
            }
            return result;
        }
