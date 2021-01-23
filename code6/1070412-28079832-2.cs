     void usr_Back(TenderUI sender, TenderUI previous)
        {
            pnlUI.Controls.Remove(sender);
    
            if (help.Previous != null)
            {
                foreach (Control ctr in help.Previous)
                {
                    pnlUI.Controls.Add(ctr);
                }
            }
        }
     
