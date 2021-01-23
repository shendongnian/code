    //FixedLengthReader.cs
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Reflection;
    
    namespace FixedLengthFileReader
    {
        class FixedLengthReader
        {
            private Stream stream;
            private byte[] buffer;
    
            public FixedLengthReader(Stream stream)
            {
                this.stream = stream;
                this.buffer = new byte[4];
            }
    
            public void read<T>(T data)
            {
                foreach (FieldInfo fi in typeof(T).GetFields())
                {
                    foreach (object attr in fi.GetCustomAttributes())
                    {
                        if (attr is LayoutAttribute)
                        {
                            LayoutAttribute la = (LayoutAttribute)attr;
                            stream.Seek(la.index, SeekOrigin.Begin);
                            if (buffer.Length < la.length) buffer = new byte[la.length];
                            stream.Read(buffer, 0, la.length);
    
                            if (fi.FieldType.Equals(typeof(int)))
                            {
                                fi.SetValue(data, BitConverter.ToInt32(buffer, 0));
                            }
                            else if (fi.FieldType.Equals(typeof(bool)))
                            {
                                fi.SetValue(data, BitConverter.ToBoolean(buffer, 0));
                            }
                            else if (fi.FieldType.Equals(typeof(string)))
                            {
                                // --- If string was written using UTF8 ---
                                byte[] tmp = new byte[la.length];
                                Array.Copy(buffer, tmp, tmp.Length);
                                fi.SetValue(data, System.Text.Encoding.UTF8.GetString(tmp));
                                
                                // --- ALTERNATIVE: Chars were written to file ---
                                //char[] tmp = new char[la.length - 1];
                                //for (int i = 0; i < la.length; i++)
                                //{
                                //    tmp[i] = BitConverter.ToChar(buffer, i * sizeof(char));
                                //}
                                //fi.SetValue(data, new string(tmp));
                            }
                            else if (fi.FieldType.Equals(typeof(double)))
                            {
                                fi.SetValue(data, BitConverter.ToDouble(buffer, 0));
                            }
                            else if (fi.FieldType.Equals(typeof(short)))
                            {
                                fi.SetValue(data, BitConverter.ToInt16(buffer, 0));
                            }
                            else if (fi.FieldType.Equals(typeof(long)))
                            {
                                fi.SetValue(data, BitConverter.ToInt64(buffer, 0));
                            }
                            else if (fi.FieldType.Equals(typeof(float)))
                            {
                                fi.SetValue(data, BitConverter.ToSingle(buffer, 0));
                            }
                            else if (fi.FieldType.Equals(typeof(ushort)))
                            {
                                fi.SetValue(data, BitConverter.ToUInt16(buffer, 0));
                            }
                            else if (fi.FieldType.Equals(typeof(uint)))
                            {
                                fi.SetValue(data, BitConverter.ToUInt32(buffer, 0));
                            }
                            else if (fi.FieldType.Equals(typeof(ulong)))
                            {
                                fi.SetValue(data, BitConverter.ToUInt64(buffer, 0));
                            }
                        }
                    }
                }
            }
        }
    }
