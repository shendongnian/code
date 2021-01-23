    private void CallOnFormLoad()
    {
        string[] allLines = File.ReadAllLines(@"C:\passwordfile.txt");
        if (allLines.Length > 1)
        {
            // at least one 2 lines:
            inlogNaamTextbox.Text = allLines[0];
            inlogPasswoordTextbox.Text = allLines[1];
        }
    }
    private void loginButton_Click(object sender, EventArgs e)
    {
        try
        {
            var sr = new System.IO.StreamReader("C:\\" + inlogNaamTextbox.Text + "\\Login.txt");
            gebruikersnaam = sr.ReadLine();
            passwoord = sr.ReadLine();
            sr.Close();
            if (gebruikersnaam == inlogNaamTextbox.Text && passwoord == inlogPasswoordTextbox.Text)
            {
                classUsername.name = inlogNaamTextbox.Text;
                MessageBox.Show("Je bent nu ingelogd!", "Succes!");
                File.WriteAllLines(@"C:\passwordfile.txt", string.Format("{0}\n{1}", inlogNaamTextbox.Text, inlogPasswoordTextbox.Text))
                // Don't call Dispose!
                // this.Dispose();
            }
            else
            {
                MessageBox.Show("Gebruikersnaam of wachtwoord fout!", "Fout!");
            }
        }
        catch (System.IO.DirectoryNotFoundException ex)
        {
            MessageBox.Show("De gebruiker bestaat niet!", "Fout!");
        }
    }
