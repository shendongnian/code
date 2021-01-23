    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            [
                {
                    ""_id"": 160,
                    ""location"": {
                        ""type"": ""Point"",
                        ""coordinates"": [ 43.59043144045182, 39.72119003534317 ]
                    }
                },
                {
                    ""_id"": 161,
                    ""location"": {
                        ""type"": ""LineString"",
                        ""coordinates"": [
                            [ 43.58780105200211, 39.719191789627075 ],
                            [ 43.58817794899264, 39.719465374946594 ]
                        ]
                    }
                },
                {
                    ""_id"": 152,
                    ""location"": {
                        ""type"": ""Polygon"",
                        ""coordinates"": [
                            [ 43.590524759627954, 39.71930980682373 ],
                            [ 43.590474249766544, 39.71926689147949 ],
                            [ 43.59043151061995, 39.71934735774994 ],
                            [ 43.59073456936772, 39.71958339214325 ],
                            [ 43.59076565222992, 39.71949219703674 ]
                        ]
                    }
                }
            ]";
            List<Shape> shapes = JsonConvert.DeserializeObject<List<Shape>>(json);
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Id: " + shape.Id);
                Console.WriteLine("Type: " + shape.Type);
                Console.WriteLine("Coordinates: ");
                foreach (List<double> point in shape.Coordinates)
                {
                    Console.WriteLine("   (" + point[0] + ", " + point[1] + ")");
                }
                Console.WriteLine();
            }
        }
    }
