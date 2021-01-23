    //you will need to replace path with the actual path to the file.
            string[] file = File.ReadAllLines("path");
            int[] age = new int[(file.Count()];
            int[] districts = new int[file.Count()];
            int counter = 0;
            foreach (var item in file)
            {
                string[] values = item.Split(',');
                age[counter] = Convert.ToInt32(values[0]);
                districts[counter] = Convert.ToInt32(values[3]);
                counter++
            }
            
