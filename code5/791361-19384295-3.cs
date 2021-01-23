         class Item
         {
            public string Id {get;set;} //this is the first property i would later bind
            public string Name {get;set;} //this is the second property
             
            public Item(string id, string name)  // this is the contructor, every time
                                                 // an instance of Item is created, this
                                                 // method is called
            {
               Id = id;
               Name = name;
            }
         }
