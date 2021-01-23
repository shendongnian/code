    static void Main(string[] args)
            {
                string path = "file.xml";
    
                Map mymap = new Map();
                var xml = XDocument.Load(path);
                var map = xml.Descendants("Map").Select(x => new Map()
                    {
                        Structures = x.Element("StructuresList").Elements("Structure").Select(r => new StructuresList()
                        {
                            Name = r.Attribute("name").ToString(),
                            Attack = r.Attribute("attack").ToString(),
                            I = r.Attribute("i").ToString(),
                            J = r.Attribute("j").ToString(),
                            Range = r.Attribute("range").ToString(),
                            Price = r.Attribute("price").ToString()
    
                        }).ToList(),
    
                        Enemys = x.Element("EnemysList").Elements("Enemy").Select(r => new EnemysList()
                        {
                            ID = r.Attribute("id").ToString(),
                            Color = r.Attribute("color").ToString(),
                            HP = r.Attribute("hp").ToString(),
                            Orobyte = r.Attribute("orobyte").ToString(),
                            Speed = r.Attribute("speed").ToString()
                        }).ToList(),
    
                        Waves = x.Element("Waves").Elements("Wave").Select(y => new Wave()
                        {
                            Groups = y.Elements("Group").Select(r => new Group()
                            {
                                ID = r.Attribute("id").ToString(),
                                Count = r.Attribute("count").ToString()
                            }).ToList()
                        }).ToList()
                    });
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
    
                public string Attack { set; get; }
    
                public string I { set; get; }
    
                public string J { set; get; }
    
                public string Range { set; get; }
    
                public string Price { set; get; }
            }
    
            internal class EnemysList
            {
    
                public string ID { set; get; }
                public string Color { set; get; }
                public string HP { set; get; }
    
                public string Orobyte { set; get; }
                public string Speed { set; get; }
    
            }
    
            internal class Wave
            {
                public List<Group> Groups { set; get; }
            }
    
            internal class Group
            {
                public string ID { set; get; }
    
                public string Count { set; get; }
            }
