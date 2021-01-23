            Image img1 = new Image();
            Image img2 = new Image();
            Image img3 = new Image();
            
            img1.Tag = "tag1";
            img2.Tag = "tag2";
            img3.Tag = "tag3";
            Dictionary<string, Image> ImgDictionary = new Dictionary<string, Image>();
            ImgDictionary.Add(img1.Tag.ToString(), img1);
            ImgDictionary.Add(img2.Tag.ToString(), img2);
            ImgDictionary.Add(img3.Tag.ToString(), img3);
            foreach (KeyValuePair<string, Image> i in ImgDictionary)
            {
                // do stuff with i.Value or i.Key 
            }
            string tmp_TagName = "tag1";
            if (ImgDictionary.ContainsKey(tmp_TagName))
            {
                Image ReturnImage;
                ImgDictionary.TryGetValue("tag1", out ReturnImage);
                // do something with your ReturnImage...
            }
