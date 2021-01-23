    using System;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            string str = "Hello\u263AWorld";
    
            var bytes = Encoding.UTF8.GetBytes(str);
            var decoder = Encoding.UTF8.GetDecoder();
            
            // Long enough for the whole string
            char[] buffer = new char[100];
            
            // Convert the first "packet"
            var length1 = decoder.GetChars(bytes, 0, 6, buffer, 0);
            // Convert the second "packet", writing into the buffer
            // from where we left off
            // Note: 6 not 7, because otherwise we're skipping a byte...
            var length2 = decoder.GetChars(bytes, 6, bytes.Length - 6,
                                           buffer, length1);
            var reconstituted = new string(buffer, 0, length1 + length2);
            Console.WriteLine(str == reconstituted); // true        
        }
    }
