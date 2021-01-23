    class Program
    {
        static void Main(string[] args)
        {
            PrintCityState(GetCityState("Grand Rapids, New Mexico"));
            PrintCityState(GetCityState("Sacremento California"));
            PrintCityState(GetCityState("Indianpolis, IN"));
            PrintCityState(GetCityState("Phoenix AZ"));
        }
        public static void PrintCityState(CityState cs)
        {
            Console.WriteLine("{0}, {1} ({2})", cs.City, cs.StateAbbreviation, cs.StateName);
        }
        public static CityState GetCityState(string input)
        {
            string truncatedInput = input;
            var statesDictionary = new Dictionary<string, string>
            {
                {"AZ", "Arizona"},
                {"NM", "New Mexico"},
                {"CA", "California"},
                {"WA", "Washington"},
                {"OR", "Oregon"},
                {"MI", "Michigan"},
                {"IN", "Indiana"}
                // And so forth for all 50 states
            };
            var cityState = new CityState();
            foreach (KeyValuePair<string, string> kvp in statesDictionary)
            {
                if (input.Trim().ToLower().EndsWith(" " + kvp.Key.ToLower()))
                {
                    cityState.StateName = kvp.Value;
                    cityState.StateAbbreviation = kvp.Key;
                    truncatedInput = input.Remove(input.Length - 1 - kvp.Key.Length);
                    break;
                }
                if (input.Trim().ToLower().EndsWith(" " + kvp.Value.ToLower()))
                {
                    cityState.StateName = kvp.Value;
                    cityState.StateAbbreviation = kvp.Key;
                    truncatedInput = input.Remove(input.Length - 1 - kvp.Value.Length);
                    break;
                }
            }
            cityState.City = truncatedInput.Trim().Trim(',').Trim();
            return cityState;
        }
    }
    public class CityState
    {
        public string City { get; set; }
        public string StateName { get; set; }
        public string StateAbbreviation { get; set; }
    }
