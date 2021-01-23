        const string EMPTYLINE="                                                                                                                                ";   
        public static int GetDefaultItemWidth(string text,System.Drawing.Font font=null)
        {
            if (font == null)
                font = System.Drawing.SystemFonts.DefaultFont;
 
            return System.Windows.Forms.TextRenderer.MeasureText(text, font).Width;
        }
        public static List<string> GetAlined(List<string> inputString)
        {
            double max = default(double);
            var spaceWidth = GetDefaultItemWidth(" ");
            foreach (var item in inputString)
            {
                var width = GetDefaultItemWidth(item);
                max = Math.Max(max, width);
            }
            
            List<string> resultItems = new List<string>(inputString.Count);
            foreach (var item in inputString)
            {
                var width = GetDefaultItemWidth(item);
                if ((max - width) > spaceWidth)
                {
                    var spaceCount = (int)Math.Round((max - width) / spaceWidth);
                    string resultItem = item;
                    resultItem=EMPTYLINE.Take(spaceCount).ToString() + resultItem;
                    resultItems.Add(resultItem);
                }
                else
                {
                    resultItems.Add(item);
                }
            }
            return resultItems;
        }
