        public SpaceProbeView(int numberOfSpaces)
        {
            mapSize = numberOfSpaces;
            rowSize = (int)Math.Sqrt(mapSize);
            Size = new System.Drawing.Size(mapSize *5, mapSize * 5);
        }
