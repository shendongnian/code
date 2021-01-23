        void InitFont()
        {
            System.Drawing.Text.PrivateFontCollection privateFontCollection =
               new System.Drawing.Text.PrivateFontCollection();
            privateFontCollection.AddFontFile("../../6px-Normal.ttf");
            solidBrush = new SolidBrush(Color.Black);
            FontFamily[] fontFamilies = privateFontCollection.Families;
            regFont = new Font(fontFamilies[0], 6);
        }
