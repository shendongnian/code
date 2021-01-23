            Dictionary<int, Guid> dic = new Dictionary<int, Guid>();
            int i = 0;
            while (i < 20)
            {
                dic.Add(i, Guid.NewGuid());
                i++;
            }
            // Now order by the guid.
            var newDic = dic.OrderByDescending(item => item.Value).ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
            int iSetter = 0;
            foreach (Control item in Controls)
            {
                Button button = new Button();
                int number = newDic.ElementAt(iSetter++).Value;
                button.Name = number.ToString();
                if (button.Name == 1.ToString() || button.Name == 2.ToString())
                {
                    Icon myIcon = (Icon)Resources.ResourceManager.GetObject(@"C:\Users\richa\Desktop\Goat.png");
                    button.Image = myIcon.ToBitmap();
                }
                Controls.Add(button);
            }
