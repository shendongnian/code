    public class finallist {
      public string name { get; set; }
      public List<object[]> data { get; set; }
    }
    var D1data = new List<object[]>
    { 
         new object[] { new DateTime(2014, 1, 1, 00,00,05),  1},
         new object[] { new DateTime(2014, 1, 1, 00,00,10),  1},
         new object[] { new DateTime(2014, 1, 1, 00,00,15),  0},
         new object[] { new DateTime(2014, 1, 1, 00,00,20),  1},
         new object[] { new DateTime(2014, 1, 1, 00,00,25),  3},
         new object[] { new DateTime(2014, 1, 1, 00,00,30),  2},
         new object[] { new DateTime(2014, 1, 1, 00,00,35),  1},
         new object[] { new DateTime(2014, 1, 1, 00,00,40),  1},
         new object[] { new DateTime(2014, 1, 1, 00,00,45),  3},
         new object[] { new DateTime(2014, 1, 1, 00,00,50),  1},
         new object[] { new DateTime(2014, 1, 1, 00,01,15),  2}
    };
    List<finallist> Finaldata = new List<finallist>();
    Finaldata.Add(new finallist { name = "D1", data = D1data });
    return  JsonConvert.SerializeObject(Finaldata, Formatting.Indented);
