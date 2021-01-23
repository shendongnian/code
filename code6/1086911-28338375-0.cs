     private void boutonFinaliserCommande_Click(object sender, RoutedEventArgs e) // Lors de l'appui sur le bouton "Finaliser la Commande", ou "Terminer"
    {
        Commande nouvelleCommande = new Commande();
        nouvelleCommande.ListePlats = new List<Plat>();
        foreach(var item in platsChoisis) // On récupère chaque plat dans la liste des plats que l'on a choisi
        {
            nouvelleCommande.Plat.Attach(item); //Add this
            nouvelleCommande.ListePlats.Add(item);
            MessageBox.Show(String.Format("id: {0}", item.platId));
        }
        nouvelleCommande.Traite = false; // False car on a pas encore encaissé le paiement
        nouvelleCommande.ResponsableId = (listBoxResponsable.SelectedItem as Serveur).serveurId;
        if(nouvelleCommande.ListePlats.Count <= 1)
        {
            MessageBox.Show("Vous n'avez renseigné aucun plat", "Commande Impossible", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        if(nouvelleCommande.ResponsableId == 0)
        {
            MessageBox.Show("Vous devez choisir un Responsable de table", "Commande Impossible", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        raiseNewCommandEvent(this, nouvelleCommande); // On envoi la nouvelle commande à la fenêtre principale qui lui affectera la table
        this.Close();
    }
