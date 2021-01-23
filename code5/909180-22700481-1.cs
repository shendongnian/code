    public bool FindText(string TextToFind)
    {
        if(txtNotePad.Text.Contains(TextToFind))
        {
            return true; //found match
        }
        else
        {
            return false; //didn't found match
        }
    }
