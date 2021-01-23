            decimal r;
            decimal g;
            decimal b;
            string rec;
            string[] fields;
            List<RGBColour> originalColourList = new List<RGBColour>();
           
            using (StreamReader sr = new StreamReader(@"c:\temp\rgb.txt"))
            {
                while (null != (rec = sr.ReadLine()))
                {
                    if (rec.EndsWith("SRGB"))
                    {
                        fields = rec.Split(' ');
                        if (fields.Length == 4 
                            && decimal.TryParse(fields[0], out r) 
                            && decimal.TryParse(fields[1], out g) 
                            && decimal.TryParse(fields[2], out b)
                            && (r+g+b !=0)
                            && (r != 1  && g != 1 && b!=1)
                            )
                        {
                            RGBColour rgbColour = new RGBColour() { Red = r, Green = g, Blue = b };
                            originalColourList.Add(rgbColour);
                        }
                    }
                }
            }
