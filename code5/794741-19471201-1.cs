    if (!System.IO.File.Exists("menu.txt"))
                return;
            string[] values;
            double price;
            List<FoodData> lines = new List<FoodData>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader("menu.txt"))
            {
                while (sr.Peek() > -1)
                {
                    values = sr.ReadLine().Split(' ');
                    FoodData tmp = new FoodData();
                    tmp.FoodName = values[0];
                    tmp.Price = Convert.ToDouble(values[1]);
                    lines.Add(tmp);
                }
            }
