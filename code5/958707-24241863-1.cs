        string operation = String.Empty;
        using (Stream s = new FileStream("filename.txt", FileMode.Open))
        {
            byte[] buffer = new byte[1024];
            string text = String.Empty;
            while (s.Read(buffer, 0, buffer.Length) > 0)
            {
                text += Encoding.UTF8.GetString(buffer);
                if (text.Contains("$START"))
                {
                    operation = text.Substring(0, text.IndexOf("$START"));
                    break;
                }
            }
        }
        Console.WriteLine("Your operation: {0}", operation);
