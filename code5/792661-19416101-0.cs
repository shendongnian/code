        void ButtonClck(object sender, eventargs e)
        {
            Button clickedbutton = (Button)sender;
            if ((string)clickedbutton.Tag = "A")
            {
                print ("Correct");
            } 
            else
            {
                print ("Incorrect");        
            }
        }
