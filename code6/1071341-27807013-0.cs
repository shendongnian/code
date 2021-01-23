    public class Program
    {
        // harcode all data as string
        const string RawData =
            "k11,k12,k13=3.4;" +
            "k21,k22,k23=4.42;" +
            "k31,k32,k33=5.91;" +
            "k41,k42,k43=8.14;" +
            "k51,k52,k53=4.13;" +
            "k61,k62,k63=5.4";
     
        static void Main(string[] args)
        {
            // create dictionary from hardcoded string
            var data = ParseData();
            // use Tuple as key for data lookup
            var value = data[Tuple.Create("k11", "k12", "k13")];
            // check, that value equals expected one
            Debug.Assert(value == 3.4);
        }
        private static IDictionary<Tuple<string, string, string>, double> ParseData()
        {
            var parsedData =
                RawData
                    .Split(';')
                    .Select(ParseRow)
                    .ToDictionary(x => x.Item1, x => x.Item2);
            return parsedData;
        }
        private static Tuple<Tuple<string, string, string>, double> ParseRow(string row)
        {
            var parts = row.Split('=');
            var coefficients = ParseCoefficients(parts[0]);
            var value = Double.Parse(parts[1], CultureInfo.InvariantCulture);
            return Tuple.Create(coefficients, value);
        }
        private static Tuple<string, string, string> ParseCoefficients(string row)
        {
            var coeffs = row.Split(',');
            var result = Tuple.Create(coeffs[0], coeffs[1], coeffs[2]);
         
            return result;
        }
    }
