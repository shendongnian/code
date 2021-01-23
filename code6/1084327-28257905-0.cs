            private static readonly Dictionary<string, XlColors> WordColoring = new Dictionary<string, XlColors>
                           {
                                {"linksaf", XlColors.Red},
                                {"schuin links", XlColors.Red},
                                {"links aanhouden", XlColors.Red},
                                {"rechtsaf", XlColors.Greenish},
                                {"schuin rechts", XlColors.Greenish},
                                {"rechts aanhouden", XlColors.Greenish},
                                {"rechtdoor", XlColors.Blue}
                           };
        public void TekstFormatter(Range cell)
        {
            string text = (cell.Value2 ?? "");
            foreach (KeyValuePair<string, XlColors> colorPair in WordColoring)
            {
                int pos = text.IndexOf(colorPair.Key, StringComparison.OrdinalIgnoreCase);
                if (pos != -1)
                {
                    Characters chars = cell.Characters[pos + 1, colorPair.Key.Length];
                    chars.Font.Color = colorPair.Value;
                    chars.Font.Bold = true;
                }                
            }
        }
