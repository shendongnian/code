    public class GameMessage 
        {
     
            private static int SortFieldInfo(FieldInfo left, FieldInfo right)
            {
                if (left.Equals(right))
                {
                    return 0;
                }
                if (right.Name == "ID")
                    return 1;
                else if (right.FieldType.Name == "String")
                    return -1;
                else 
                    return 0;
            }
            public GameMessage(){}
            public GameMessage(byte[] data)
            {
                List<byte> bytes = new List<byte>();
                List<FieldInfo> info = new List<FieldInfo>(this.GetType().GetFields());
                info.Sort(SortFieldInfo);
                int idx = 0;
                for (int i = 0; i < info.Count; i++)
                {
                    if (info[i].FieldType.Name == "String")// is string)
                    {
                        string value;
                        UInt16 size;
                        if (i != info.Count - 1)
                        {
                            size = BitConverter.ToUInt16(data, idx);
                            idx += 2;
                            value = ASCIIEncoding.ASCII.GetString(data, idx, size);
                            idx += size;
                        }
                        else
                        {
                            value = ASCIIEncoding.ASCII.GetString(data, idx, data.Length - idx);
                            idx += data.Length - idx;
                        }
                      
                        info[i].SetValue(this,value);
                    }
                    else
                    {
                        if (info[i].Name != "ID")
                        {
                            Type[] types = new Type[2] { data.GetType(), idx.GetType() };
                            object[] values = new object[2] { data, idx };
                            info[i].SetValue(this, typeof(BitConverter).GetMethod("To" + info[i].FieldType.Name, types).Invoke(null, values));
                            idx += Marshal.SizeOf(info[i].FieldType);
                        }
                        else
                        {
                            idx += sizeof(ID);
                        }
                    }
                }
      
            }
            public byte[] ToByte()
            {
                List<byte> bytes = new List<byte>();
                List<FieldInfo> info = new List<FieldInfo>(this.GetType().GetFields());
                info.Sort(SortFieldInfo);
                for(int i=0;i<info.Count;i++)
                {
                    if (info[i].FieldType.Name == "String")
                    {
                        if (i != info.Count - 1)
                        {
                            bytes.AddRange(BitConverter.GetBytes(((UInt16)((string)info[i].GetValue(this)).Length)));
                        }
                        bytes.AddRange(ASCIIEncoding.ASCII.GetBytes((string)info[i].GetValue(this)));
                    }
                    else
                    {
                        bytes.AddRange((byte[])typeof(BitConverter).GetMethod("GetBytes", new Type[] { info[i].FieldType }).Invoke(null, new object[] { info[i].GetValue(this) }));
                    }
              }
                return bytes.ToArray();
            }
        }
