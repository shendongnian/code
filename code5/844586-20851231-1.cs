        static void Main()
        {
            // create array of 4 string (or answers in your case)
            //string[] array = new string[4] { "apple", "banana", "cranberry", "dragon fruit" };            
            string[] array = new string[4] {
                ds.Tables[0].Rows[myNum]["CorrectAnswer"].ToString(),
                ds.Tables[0].Rows[myNum]["WrongAnswer1"].ToString(),
                ds.Tables[0].Rows[myNum]["WrongAnswer2"].ToString(),
                ds.Tables[0].Rows[myNum]["WrongAnswer3"].ToString(),
            };
            // randomize the ordering of the items
            System.Random rnd = new System.Random();
            array = array.OrderBy(x => rnd.Next()).ToArray();
            // each time you run this, the correct answer will be in a different place:
            btn1.Text = array[0];
            btn2.Text = array[1]; 
            btn3.Text = array[2];
            btn4.Text = array[3];
 
        }
