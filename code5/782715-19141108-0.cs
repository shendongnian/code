    byte[] bitMapData = dr[2] as byte[] ?? null;
            if (bitMapData != null)
            {
                using (MemoryStream stream = new MemoryStream(bitMapData))
                {
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream);
                }
            }
