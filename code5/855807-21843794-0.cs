    list = new List<byte[]>();
                for (int i = 0; i < arr1.Count; i++)
                {
                    img = Image.FromFile(arr1[i].ToString());
                    ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    list.Add(ms.ToArray());
                }
    
                image_Name.Add(arr1, list);
                //image_Name[arr1 as ArrayList] = [list as byte[]];
                return image_Name;
            }
