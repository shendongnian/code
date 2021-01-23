            using (System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (MemoryTributary memT = new MemoryTributary())
                {
                    
                    memT.ReadFrom(stream, stream.Length);
                    return memT.ToArray();
                }
            }
