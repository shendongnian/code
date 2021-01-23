    public static class Spice
    {
        public enum Level
        {
            Low = 1,
            Medium = 2,
            Hot = 3
        }
        private static readonly Dictionary<string, Level> spices = new Dictionary<string, Level>{
            { "Red Rose", Level.Low },
            { "White Rose", Level.Medium },
            { "Black Rose", Level.Hot },
        };
        public static bool TryGet(string spiceName, out Level spiceLevel) => spices.TryGetValue(spiceName, out spiceLevel);
        public static string SpiceName(Level target) => Enum.GetName(typeof(Spice.Level), target);
    }
    /// <summary>
    /// Some tests to validate it works. This could be a unit test or just in a console app
    /// </summary>
    public class SpiceTest
    {
        public void VerifyGoodValueReturnsTrue()
        {
            string subject = "White Rose";
            Spice.Level expectedSpice;
            // Here's the ease of use. Pass a string, get an enum and whether it's a valid string
            var result = Spice.TryGet(subject, out expectedSpice);
            //Some Assertion from a unit test library
            Assert.True(result, $"Unable to find spice '{subject}', when it should exist");
            Assert.True(Spice.Level.Hot.Equals(expectedSpice), $"The returned spice '{ Spice.SpiceName(expectedSpice) }' was not the value 'Hot' as expected");
        }
    }
