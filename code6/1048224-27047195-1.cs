            return File.ReadAllLines(path);
        }
        public void WriteToFile(string path, IList<Creature> creatureCollection)
        {
            using (StreamWriter stream = File.AppendText(path))
            {
                foreach(var creature in creatureCollection)
                {
                    stream.WriteLine(creature.Name);
                }
            }
        }
