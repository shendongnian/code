        class GlobalData
        {
            private string[] array = new string[10];
            public GlobalData()
            {
               //now initialize array
               array[0] = "SomeThingA";
               array[1] = "SomeThingB";//continue initialization.
            }
            public string this[int index]
            {
                get {return array[index];}
            }
        }
