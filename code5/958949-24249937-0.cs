    private void NewsUpdate()
    {
        if (counter == 10)
        {
            timer1.Stop(); //Why tick if we are done?
            ...
    
            //counter = 0; //Why reset this?
        }
        else
        {
           counter += 1;
    
           //progressBar1.Value = counter * 10; //Huh? We set it again in the next statement
           progressBar1.Value = counter;
        }
    
        //Perhaps this goes in the else also, not enough information for me to determine:
        label9.Text = counter.ToString();
        label9.Visible = true;
    }
