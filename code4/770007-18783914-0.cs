        public class Name                    // can not touch this class OR modify it
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string GetNames()
            {
                return FirstName + " " + LastName;
            }
        }
        public class Name1:Name {
            public string EmailAddress { get; set; }
            public override string GetNames()
            {
                return FirstName + " " + LastName+" "+EmailAddress;
            }
            
        }
        public class Details
        {
            // some methods and properties.
            public Name LoadName()          // This method return type i can not change as this method is used in ObjectDataSource for GridView
            {
                TextBox txtInpput = new TextBox();
                var names = new Name();
                if (txtInpput.Text == "Jermy")
                {
                    names.FirstName = "Jermy";
                    names.LastName = "Thompson";
                }
                else
                {
                    names.FirstName = "Neville";
                    names.LastName = "Vyland";
                }
                return
                names;
            }
        }
        public  class Details1:Details {
            public override Name LoadName()          
            {
                TextBox txtInpput = new TextBox();
                var names = new Name();
                if (txtInpput.Text == "Jermy")
                {
                    names.FirstName = "Jermy";
                    names.LastName = "Thompson";
                }
                else
                {
                    names.FirstName = "Neville";
                    names.LastName = "Vyland";
                }
                return
                names;
            }
        }
