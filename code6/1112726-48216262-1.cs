         var decryptor = algo.CreateDecryptor(....);
         int BLOCK_SIZE_IN_BYTES = algo.BlockSize / 8;
         int READ_SIZE = BLOCK_SIZE_IN_BYTES*16; // Some multiple of BLOCK_SIZE_IN_BYTES
         MemoryStream decryptedStream = new MemoryStream(READ_SIZE*4); // allocate a buffer
         StreamReader clientReader = new StreamReader(decryptedStream);
         
         byte[] buff = new byte[READ_SIZE];
         while (true)
         {
            int len = 0;
            while ((len = clientInputStream.Read(buff, 0, READ_SIZE)) > 0)
            {
               int leftover = len % BLOCK_SIZE_IN_BYTES;
               len = len - leftover; // get full blocks
               // if it is big enough then we can decrypt it
               if (len > 0)
               {
                  decryptor.TransformBlock(buff, 0, len, buff, 0);
                  decryptedStream.Write(buff, 0, len);
                  decryptedStream.Seek(-len, SeekOrigin.End);
                  Console.WriteLine("Written " + len + " bytes to memory buffer");
                  do
                  {
                     var line = clientReader.ReadLine();
                     if (null != line)
                     {
                        line = line.Replace('\x1', ' '); // replace padding bits (for me padding is 1 bit and so the value is 1, if you use base64 encoding then use the no-padding option)
                        Console.WriteLine(String.Join(" ", line.Select(x => String.Format("{0:X}", Convert.ToInt32(x)))));
                        line = line.Trim();
                        Console.WriteLine(line);
                        Console.WriteLine("end line " + lineno);
                        lineno++;
                     }
                  } while ((!content.EndOfStream));
               } //if
               if (leftover > 0)
               {
                  clientInputStream.Seek(-leftover, SeekOrigin.Current);
                  break;
               }
            }
            var cmd = Console.ReadLine("Want more Line?");
         }
