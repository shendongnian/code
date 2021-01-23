    internal class Program {
        private static object UnwrapAngle(double angle) {
            if (angle >= 0) {
                var tempAngle = angle % 360;
                return tempAngle == 360 ? 0 : tempAngle;
            }
            else
                return 360 - (-1 * angle) % 360;
        }
        private static void TestUnwrap(double angle, double expected) {
            Console.WriteLine(String.Format("{0} unwrapped = {1}, expected {2}", angle, UnwrapAngle(angle), expected));
        }
        private static void Main(string[] args) {
            TestUnwrap(0, 0);
            TestUnwrap(360, 0);
            TestUnwrap(180, 180);
            TestUnwrap(360 + 180, 180);
            TestUnwrap(-270, 90);
            TestUnwrap(-270 - 720, 90);
            TestUnwrap(-725, 355);
            Console.ReadLine();
        }
    }
