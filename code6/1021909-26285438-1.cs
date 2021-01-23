        public void button_click(object sender,EventArgs e)
        {
            if(sender is ButtonCtrl)
            {
                ButtonCtrl btnCtrl= sender as ButtonCtrl;
                label1.Text = btnCtrl.Arg1.ToString() + " " + btnCtrl.Arg2.ToString();
            }
        }
