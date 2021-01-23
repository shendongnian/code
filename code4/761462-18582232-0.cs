    void txtTest_TextChanged(object sender, TextChangedEventArgs e)
    {
        _game.SetHighscoreName(txtTest.Text);
        Debug.WriteLine(txtTest.Text); //Write content to public string in Main.cs
    }
