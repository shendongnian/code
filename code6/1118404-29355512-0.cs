    //you will need to replace path with the actual path to the file.
            string[] file = File.ReadAllLines("path");
            List<int> ageList = new List<int>(file.Count());
            List<int> districtsList = new List<int>(file.Count());
            foreach (var item in file)
            {
                string[] values = item.Split(',');
                ageList.Add(Convert.ToInt32(values[0]));
                districtsList.Add(Convert.ToInt32(values[3]));
            }
            int[] age = ageList.ToArray();
            int[] districts = districtsList.ToArray();
