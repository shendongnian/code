        private static void AddStyles(StreamWriter writer, int groupCount)
                {
                    writer.WriteLine("<Styles>");
        
                    for (int i = 0; i < groupCount; i++)
                    {
                        int shift = i % _headerColor.Count();
                        var color = _headerColor[shift];
                        writer.WriteLine("<Style ss:ID=\"st{0}\">", i + 1);
                        writer.WriteLine("<Interior ss:Color=\"#{0:X2}{1:X2}{2:X2}\" ss:Pattern=\"Solid\"/>", color.R, color.G, color.B);
                        writer.WriteLine("</Style>");
                    }
        
                    writer.WriteLine("</Styles>");
                }
