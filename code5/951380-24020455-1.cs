    Form1: Form
    {
        List<Button> listButtons = new List<Button>();
        public void EnableButton(Button btnToEnable)
        {
            foreach(Button btn in listButtons)
            {
                //check button name.
                //if it is the button to enable, enable it, if not then disable it
                btn.Enabled = btn.Name == btnToEnable.Name;
            }
        }
        Form_Load(Object sender, event Args e)
        {
            listButtons.Add(Button1);
            listButtons.Add(Button2);
            listButtons.Add(Button3);
            EnableButton(Button1);
            //Button1.Enabled = true;
            //Button2.Enabled = false;
            //Button3.Enabled = false;
        }
        Button1_click(Object sender, event Args e)
        {
            EnableButton(Button2);
            //Actions
            //Button2.Enabled = true;
            //Button1.Enabled = false;
        }
        Button2_click(Object sender, event Args e)
        {
            EnableButton(Button3);
            //Actions
            //Button3.Enabled = true;
            //Button2.Enabled = false;
        }
        Button3_click(Object sender, e)
        {
            EnableButton(Button1);
            //Actions
            //Button3.Enabled = false;
            //Button1.Enabled = true;
        }
    }
