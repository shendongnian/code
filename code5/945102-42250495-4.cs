    public class OrderParameterUriParser
    {
        public bool TryParse(string input, out OrderParameter result)
        {
            result = null;
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            var parts = input.Split(',');
            result = new OrderParameter();
            result.OrderBy = parts[0];
            int orderDirection;
            if (parts.Length > 1 && int.TryParse(parts[1], out orderDirection))
            {
                result.OrderDirection = orderDirection;
            }
            else
            {
                result.OrderDirection = 0;
            }
            return true;
        }
    }
