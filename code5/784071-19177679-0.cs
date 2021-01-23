     Array splitString = myData.Split(' ');
            Grid viewGrid = new Grid(Coordinates(int.Parse(splitString[0]), int.Parse(splitString[1])));
            int i = 2;
            while (i < splitString.Length) {
                int x = int.Parse(splitString[i++]);
                int y = int.Parse(splitString[i++]);
                char c = Convert.ToChar(splitString[i++]);
                string s = Convert.ToInt32(splitString[i++]);
                viewGrid.AddToCollection(new Rov(x, y, c, s));
            }
