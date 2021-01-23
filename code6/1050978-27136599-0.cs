        private void HistoGram()
        {
            // Get your image in a bitmap; this is how to get it from a picturebox
            Bitmap bm = (Bitmap) pictureBox1.Image;  
            // Store the histogram in a dictionary          
            Dictionary<Color, int> histo = new Dictionary<Color,int>();
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    // Get pixel color 
                    Color c = bm.GetPixel(x,y);
                    // If it exists in our 'histogram' increment the corresponding value, or add new
                    if (histo.ContainsKey(c))
                        histo[c] = histo[c] + 1;
                    else
                        histo.Add(c, 1);
                }
            }
            // This outputs the histogram in an output window
            foreach (Color key in histo.Keys)
            {
                Debug.WriteLine(key.ToString() + ": " + histo[key]);
            }
        }
