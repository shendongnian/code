       private void button1_Click(object sender, EventArgs e)
        {
            var Atorre = Resource1.test;
            var DifferentImage = Resource1.test2;
            byte[] a = BitmapToBytes(Atorre);
            byte[] b = BitmapToBytes(DifferentImage);
            bool isEqual = true;
            if (a.Length == b.Length && a != null && b != null)
            {
                for (int i = 0; i < b.Length; i++)  //compare every byte
                {
                    if (b[i] != a[i])
                    {
                        isEqual = false;
                        break;
                    }
                }
            }
            else
            {
                isEqual = false;
            }
            if(isEqual)
                MessageBox.Show("It's EQUAL");
            else
                MessageBox.Show("Not EQUAL");
        }
        //Convert Image to Bytes 
        public static byte[] BitmapToBytes(Bitmap Bitmap)
        {
            System.IO.MemoryStream ms = null;
            try
            {
                ms = new System.IO.MemoryStream();
                Bitmap.Save(ms, Bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }
