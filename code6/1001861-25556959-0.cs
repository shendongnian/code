    messagePrompt.Completed += messagePrompt_Completed;
    messagePrompt.Show();
    void messagePrompt_Completed(object sender, PopUpEventArgs<object, PopUpResult> e)
    {
        IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
        if (iso.TryGetValue<string>("isoQuantity", out retornaNome))
        {
            qtd = retornaNome;
        }
        fi.Quantity = qtd;
        List2.Items.Add(fi);
        MessageBox.Show("Item Adicionado com sucesso!");
    };
