    private Button CreateButton(string id, string name)
            {
                Button b = new Button();
                b.Text = name;
                b.ID = id;
                b.Click += new EventHandler(Button_Click);
                b.OnClientClick = "ButtonClick('" + b.ClientID + "')";
                return b;
            }
