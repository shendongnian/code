    private void button1_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text != UsernameS)
        {
            string json = File.ReadAllText("settings.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj["Bots"][0]["Username"] = txtUsername.Text;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText("settings.json", output);
        }
        if (txtPassword.Text != PasswordS)
        {
            string json = File.ReadAllText("settings.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj["Bots"][0]["Password"] = txtPassword.Text;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText("settings.json", output);
        }
        if(txtUsername.Text != UsernameS || txtPassword.Text != PasswordS)
        {
            var filename = System.Reflection.Assembly.GetExecutingAssembly().Location;
            System.Diagnostics.Process.Start(filename);
            // Closes the current process
            Environment.Exit(0);
        }
    }
