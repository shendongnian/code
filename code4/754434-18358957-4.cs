    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            using (var file = File.OpenRead("my.txt"))
            using (var buffer = new MemoryStream())
            {
                List<string> lines = new List<string>();
                string line;
                while ((line = ReadToCRLF(file, buffer)) != null)
                {
                    lines.Add(line);
                    Console.WriteLine(line);
                    if (line == "mark" && lines.Count >= 2)
                    {
                        var match = Regex.Match(lines[lines.Count - 2], "^l ([0-9]+)$");
                        int bytes;
                        if (match.Success && int.TryParse(match.Groups[1].Value, out bytes))
                        {
                            ReadBytes(file, buffer, bytes);
                            string inflated = Inflate(buffer);
                            lines.Add(inflated); // or something similar
                            Console.WriteLine(inflated);
                        }
                    }
                }
            }
    
        }
        static string Inflate(Stream source)
        {
            using (var deflate = new DeflateStream(source, CompressionMode.Decompress, true))
            using (var reader = new StreamReader(deflate, Encoding.ASCII))
            {
                return reader.ReadToEnd();
            }
        }
        static void ReadBytes(Stream source, MemoryStream buffer, int count)
        {
            buffer.SetLength(count);
            int read, offset = 0;
            while (count > 0 && (read = source.Read(buffer.GetBuffer(), offset, count)) > 0)
            {
                count -= read;
                offset += read;
            }
            if (count != 0) throw new EndOfStreamException();
            source.Position = 0;
        }
        static string ReadToCRLF(Stream source, MemoryStream buffer)
        {
            buffer.SetLength(0);
            int next;
            bool wasCr = false;
            while ((next = source.ReadByte()) >= 0)
            {
                if(next == 10 && wasCr) { // CRLF
                    // end of line (minus the CR)
                    return Encoding.ASCII.GetString(
                         buffer.GetBuffer(), 0, (int)buffer.Length - 1);
                }
                buffer.WriteByte((byte)next);
                wasCr = next == 13;
            }
            // end of file
            if (buffer.Length == 0) return null;
            return Encoding.ASCII.GetString(buffer.GetBuffer(), 0, (int)buffer.Length);
    
        }
    }
