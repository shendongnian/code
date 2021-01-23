        static unsafe void TestUnicodeLength2()
        {
            Parallel.For(char.MinValue, char.MaxValue + 1, charVal =>
            {
                var firstChar = checked((char)charVal);
                var buffer = new string(firstChar, 2);
                fixed (char* bufferPtr = buffer)
                {
                    var currentCulture = CultureInfo.CurrentCulture;
                    for (int i = char.MinValue; i <= char.MaxValue; i++)
                    {
                        bufferPtr[1] = checked((char)i);
                        var toLower = buffer.ToLower(currentCulture);
                        if (toLower.Length != buffer.Length)
                        {
                            Console.WriteLine(buffer + " => " + toLower);
                            Debugger.Break();
                        }
                        var toUpper = buffer.ToUpper(currentCulture);
                        if (toUpper.Length != buffer.Length)
                        {
                            Console.WriteLine(buffer + " => " + toUpper);
                            Debugger.Break();
                        }
                    }
                }
            });
        }
