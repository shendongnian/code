    static void Main(string[] args)
            {
                string path =@"file.xml";
    
                Map mymap = new Map();
                var xml = XDocument.Load(path);
                var map = xml.Descendants("Map").Select(x => new Map()
                    {
                        Structures = x.Element("StructuresList").Elements("Structure").Select(r => new StructuresList()
                        {
                            Name = r.Attribute("name").Value,
                            Attack =Convert.ToInt32(r.Attribute("attack").Value),
                            I = Convert.ToInt32(r.Attribute("i").Value),
                            J = Convert.ToInt32(r.Attribute("j").Value),
                            Range = Convert.ToInt32(r.Attribute("range").Value),
                            Price = Convert.ToInt32(r.Attribute("price").Value)
    
                        }).ToList(),
    
                        Enemys = x.Element("EnemysList").Elements("Enemy").Select(r => new EnemysList()
                        {
                            ID = Convert.ToInt32(r.Attribute("id").Value),
                            Color = r.Attribute("color").Value.ToString(),
                            HP = Convert.ToInt32(r.Attribute("hp").Value),
                            Orobyte = Convert.ToInt32(r.Attribute("orobyte").Value),
                            Speed = Convert.ToInt32(r.Attribute("speed").Value)
                        }).ToList(),
    
                        Waves = x.Element("Waves").Elements("Wave").Select(y => new Wave()
                        {
                            Groups = y.Elements("Group").Select(r => new Group()
                            {
                                ID = Convert.ToInt32(r.Attribute("id").Value),
                                Count = Convert.ToInt32(r.Attribute("count").Value)
                            }).ToList()
                        }).ToList()
                    }).First();
               }
    
    
            internal class Map
            {
                public List<StructuresList> Structures { set; get; }
    
                public List<EnemysList> Enemys { set; get; }
    
                public List<Wave> Waves { set; get; }
            }
           
            internal class StructuresList
            { 
                public string Name{set;get;}
    
                public int Attack { set; get; }
    
                public int I { set; get; }
    
                public int J { set; get; }
    
                public int Range { set; get; }
    
                public int Price { set; get; }
            }
    
            internal class EnemysList
            {
    
                public int ID { set; get; }
                public string Color { set; get; }
                public int HP { set; get; }
    
                public int  Orobyte { set; get; }
                public int Speed { set; get; }
    
            }
    
            internal class Wave
            {
                public int WaveID { set; get; }
                public List<Group> Groups { set; get; }
            }
    
            internal class Group
            {
                public int ID { set; get; }
    
                public int Count { set; get; }
            }
