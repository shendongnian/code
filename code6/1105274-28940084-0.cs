    List <TextBlock> TBlocks=new List<TextBlock>();
    TBlocks.Add(t1);
    ...
    TBlocks.Add(t8);
    
    private void LetterClicked(object sender, RoutedEventArgs e)
    {
            Button btn = sender as Button;
            TBlocks[lettersTyped-1].Text= btn.Content.ToString();
    }
