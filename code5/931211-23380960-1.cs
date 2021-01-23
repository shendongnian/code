    using System;
    
    class Test
    {
        static void Main()
        {
            string base64 = "ovsvdWYOUIXU+LAfIYtOf7N60v6Qap6qBgS3IVwBG6k=";
            byte[] rawData = Convert.FromBase64(base64);
            Console.WriteLine(BitConverter.ToString(rawData));
        }
    }
