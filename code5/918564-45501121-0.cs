    public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
    {
                System.IO.Stream st = pInMsg.BodyPart.GetOriginalDataStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(st);
                var strBuilder = new StringBuilder();
                string str = string.Empty;
                while (reader.Peek() >= 0)
                {
                    str  = reader.ReadLine();
                    if (str.Length >= 998)                            
                       str = str.Replace(str.ToString(), System.Text.RegularExpressions.Regex.Replace(str.ToString(), "(.{" + 998 + "})", "$1" + Environment.NewLine));
    
                    strBuilder.AppendLine(str);
                }             
    
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                System.IO.StreamWriter writer = new System.IO.StreamWriter(m);
                writer.AutoFlush = true;
                writer.Write(strBuilder.ToString());
                m.Position = 0;
                pInMsg.BodyPart.Data = m;                
                reader.Close();
                return pInMsg;                    
    }
