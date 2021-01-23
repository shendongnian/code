            string[] Images = new string[] { "Star_00001.png", "Star_00002.png", "Star_00003.png" };
            string path = "Assets/Images/";
            if (LevelUp)
            {
                foreach (string s in Images)
                {
                    // You can store result in an array or sth depending on what you
                    // are trying to achieve
                    string result = Path.Combine(path, s);
                }
            }
