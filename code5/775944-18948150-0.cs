        public static void HighlightImages(int selection, params Image[] images)
        {
            for (int img = 0; img < images.Length; img++)
            {
                images[img].Opacity = (img == selection ? 1 : 0.5);
            }
        }
