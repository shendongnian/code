        private void SaveTextureData(Texture2D texture, string filename)
        {
            int width = texture.Width;
            int height = texture.Height;
            Color[] data = new Color[width * height];
            texture.GetData<Color>(data, 0, data.Length);
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                writer.Write(width);
                writer.Write(height);
                writer.Write(data.Length);
                for (int i = 0; i < data.Length; i++)
                {
                    writer.Write(data[i].R);
                    writer.Write(data[i].G);
                    writer.Write(data[i].B);
                    writer.Write(data[i].A);
                }
            }
        }
