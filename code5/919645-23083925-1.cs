    private void SaveToDbCommandAction()
    {
        if(PastedText.Contains("trowd"))
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("Cannot save Article. Please remove pasted tables");          
        }
        else
        {
            SaveToDb(RTBText);
        }            
    }
