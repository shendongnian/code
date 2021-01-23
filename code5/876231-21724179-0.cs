     private void method(string[] arg)
        {
            switch (arg[0])
            {
                case "a":
                    HandleCaseA();
                    break;
                case "b":
                    HandleCaseB();
                    break;
                default:
                    throw new ArgumentException("arg");
            }
        }
        private void HandleCaseA()
        {
            foreach (var c in obja)
            {
                if (c.entry == 'a')
                    HandleSubCaseA();
                else if (!(Independent_condition_3 || Independent_condition_4)
                HandleSubCaseAWithConditions3And4();
            }           
        }
        private void HandleSubCaseA()
        {
            if (!(Independent_condition_1 || Independent_condition_2))
                {
                    // Do something
                }
            }
        }
        private void HandleCaseB ()
        {
            //Do stuff
        }
        private void HandleSubCaseAWithConditions3And4()
        {
            //Do stuff
        }
    }
