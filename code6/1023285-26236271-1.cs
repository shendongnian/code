    var reqs = new Reqs {
        Source = new Source {
            Sec = new Sec {
                Name = "A",
                InnerSec = new Sec {
                    Name = "L",
                    InnerSec = new Sec {
                        Name = "B",
                        Req = new Req {
                            Content = "",
                            Title = "",
                            Pro = ""
                        }
                    }
                }
            }
        }
    };
    var ser = new XmlSerializer(typeof(Reqs));
    ser.Serialize(Console.Out, reqs);
