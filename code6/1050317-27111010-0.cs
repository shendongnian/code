    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    class Program
    {
        private static void Main()
        {
            var encoding = Encoding.GetEncoding("ISO-8859-1");
            var testString = new string(new[] { (char)0x201c });
            string roundTripped;
            using (var m = new MemoryStream())
            {
                using(var writer = new StreamWriter(m, encoding))
                {
                    var reader = new StreamReader(m, encoding);
                    writer.Write(testString);
                    writer.Flush();
                    m.Seek(0, SeekOrigin.Begin);
                    roundTripped = reader.ReadToEnd();
                }
            }
        }
        Debug.Assert(
            string.Equals(testString, roundTripped),
            "These strings should be equal.");
    }
