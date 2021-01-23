            var list = new List<cEspecie>();
            using (StreamReader reader = File.OpenText(filePath))
            {
                while(!reader.EndOfStream)
                {
                    string name = reader.ReadLine();
                    int type = int.Parse(reader.ReadLine());
                    int movility = int.Parse(reader.ReadLine());
                    int lifeTime = int.Parse(reader.ReadLine());
                    int deadTo = int.Parse(reader.ReadLine());
                    list.Add(new cEspecie(name, type, movility, lifeTime, deadTo));
                }
            }
