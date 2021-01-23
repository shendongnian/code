        private Texture2D LoadTextureData(string filename)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {                
                var width = reader.ReadInt32();
                var height = reader.ReadInt32();
                var length = reader.ReadInt32();
                var data = new Color[length];
                for (int i = 0; i < data.Length; i++)
                {
                    var r = reader.ReadByte();
                    var g = reader.ReadByte();
                    var b = reader.ReadByte();
                    var a = reader.ReadByte();
                    data[i] = new Color(r, g, b, a);
                }
                var texture = new Texture2D(GraphicsDevice, width, height);
                texture.SetData<Color>(data, 0, data.Length);
                return texture;
            }
        }
