    public static bool IsThereAnEmptyTextBox(List<TextBox> textBoxes)
    {
        bool emptyfound=false;
        foreach(TextBox tb in textboxes)
        {
            if(String.IsNullOrEmpty(tb.Text)
            {
                emptyfound=true;
            }   
        }
        return emptyfound;
    }
