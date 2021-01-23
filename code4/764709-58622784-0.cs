    using System;
    using System.Linq;
    namespace YourApp.Extensions.GuidExtensions
    {
        public static class Extension
        {
            public static Guid FirstLetter(this Guid obj)
            {
                var b = obj.ToByteArray();
                b[3] |= 0xF0;
                return new Guid(b);
            }
            public static Guid OnlyLetters(this Guid obj)
            {
                var ba = obj.ToByteArray();
                return new Guid(
                    ba.Select(b => (byte)(((b % 16) < 10 ? 0xA : b) |
                                          (((b >> 4) < 10 ? 0xA : (b >> 4)) << 4)))
                      .ToArray()
                );
            }
        }
    }
