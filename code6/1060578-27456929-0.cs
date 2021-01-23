    public void CheckLabels()
    {
        bool AllHidden = true;
        foreach (Control c in this.Controls)
        {
            if (c.GetType().Name == "Label")
            {
                if (c.Visible == true)
                {
                    AllHidden = false;
                    Break;
                }
            }
        }
        if (AllHidden)
        {
            //Do whatever you want. For example:
            this.Close();
        }
    }
