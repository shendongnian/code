    string TextToMatch = TextEdit_GroupName.Text;
    
    if(ListData.Any(x => x.Name == TextToMatch))
    {
    MessageBox.Show(string.format("{0} already exists",TextToMatch);
    }
