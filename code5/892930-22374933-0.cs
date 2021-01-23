            internal byte[] GetBuffer()
            {            
                List<byte> list = new List<byte>();
                list.Add(GifExtensions.ExtensionIntroducer); // 0x21
                list.Add(GifExtensions.CommentLabel); // 0xFE
                foreach (string coment in CommentDatas)
                {
                    char[] commentCharArray = coment.ToCharArray();
                    list.Add((byte)commentCharArray.Length);
                    foreach (char c in commentCharArray)
                    {
                        list.Add((byte)c);
                    }
                }
                list.Add(GifExtensions.Terminator); // 0
                return list.ToArray();
            }
