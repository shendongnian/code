     class Model{
        public string Email {get; set;}
        public string First_Name {get; set;}
        // bla bla
      }
     foreach(var i in Data.Skip(1)) {
          var Temp = i.Splite('\t');
          Model model = new Model{ Email = Temp[0], First_Name = Temp [1]};
     } 
