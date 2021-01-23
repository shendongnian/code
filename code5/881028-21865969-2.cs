        [XmlIgnore]
        public List<Point> listOfVertexes;
        [XmlArray("Points")]
        [XmlArrayItem("Point")]
        public string[] listOfVertexesString
        {
            get { return listOfVertexes.Select(s => s.X + "," + s.Y).ToArray(); }
            set
            {
                listOfVertexes = value
                    .Select(s => new Point
                    {
                        X = int.Parse(s.Split(',')[0]),
                        Y = int.Parse(s.Split(',')[1])
                    })
                    .ToList();
            }
        }
