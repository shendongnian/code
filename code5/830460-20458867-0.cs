    private void message(int choice, string result)
            {
               if(result == "Draw")
               {
                switch (choice)
                case 1: MessageBox.Show("It is a draw. Both chose Rock");
                break;
                case 2: MessageBox.Show("It is a draw. Both chose Paper");
                break;
                case 3: MessageBox.Show("It is a draw. Both chose Scissor");
                break;
               }
               //similarly do for the rest.
            }
