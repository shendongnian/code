    using System;
    using NUnit.Framework;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main()
            {
                Assert.That(() => Save(null, new EventArgs()), Throws.Nothing);
            }
            private static bool Save(object sender, EventArgs e)
            {
                return true;
            }
        }
    }
