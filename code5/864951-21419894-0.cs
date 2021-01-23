    public class Schedule{
      string flight {get; set; }
    string dep {get; set; }
    string deptime {get; set; }
    string arr {get; set; }
    string arrtime {get; set; }
    string ac {get; set; }
    string dur {get; set; }
    string cat {get; set; }
    string id {get; set; }
    }
    
    public List<Schedule> Schedules = new List<Schedule>();
    
    Schedule current;
    using (XmlReader reader = XmlReader.Create(fullURL))
                {
                    while (reader.Read())
                    {
                        current = new Schedule();
                        if (reader.IsStartElement())
                        {
    
                            switch (reader.Name)
                            {
    
                                case "flight":
                                    current.flight = reader.ReadElementContentAsString();
                                    break;
                                case "dep":
                                    current.dep = reader.ReadElementContentAsString();
                                    break;
                                case "deptime":
                                    current.deptime = reader.ReadElementContentAsString();
                                    textBox3.AppendText(deptime + " | ");
                                case "arr":
                                    current.arr = reader.ReadElementContentAsString();
                                    break;
                                case "arrtime":
                                    current.arrtime = reader.ReadElementContentAsString();
                                    break;
                                case "ac":
                                    var ac = reader.ReadElementContentAsString();
                                    textBox3.AppendText(ac + " | ");
                                    break;
                                case "dur":
                                    current.dur = reader.ReadElementContentAsString();
                                    break;
                                case "cat":
                                    current.cat = reader.ReadElementContentAsString();
                                    break;
                                case "id":
                                    current.Id = reader.ReadElementContentAsString();
                                    break;
    
    Schedule.Add(current)
    }
    }
    }
