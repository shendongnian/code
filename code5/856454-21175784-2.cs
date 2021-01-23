    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            var btnns = new List<Button>();
            btnns.Add(button1);
            btnns.Add(button2);
            btnns.Add(button3);
            btnns.Add(button4);
            //Shuffle the list
            Shuffle<Button>(ref btnns);
            //Add an event handler for success to your first button
            btnns[0].Click += successClick;
            btnns[0].Text = "Correct";
            for (int i = 1; i < btnns.Count; i++)
            {
                btnns[i].Click += failedClick;
                btnns[i].Text = "Wrong " + i;
            }
        }
        private void failedClick(object sender, EventArgs e)
        {
 	        //Add a true value to the viewstate list
                AddAnswer(true);
        } 
        private void successClick(object sender, EventArgs e)
        {
            //Yay, it's correct
            AddAnswer(false);
        }
        public void AddAnswer(bool correctornot)
        {
               //I am not 100% sure about the code below (not tested), but it should give you an idea
               if (Session["listOfAnswers"] != null)
               {
                    var currentList = (List<bool>) Session["listOfAnswers"];
                    currentList.Add(correctornot);
                    Session["listOfAnswers"] = currentlist;
               }
               else
               {
                   var currentlist = new List<bool>();
                   currentlist.Add(correctornot);
                   Session["listOfAnswers"] = currentlist;
                }
        }
        public void Shuffle<T>(ref List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
