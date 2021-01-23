        InvokeOperation<IEnumerable<Affaire>> LoadAffaire;
        private void IsTheSame(){
            IsBusy = true;
            LoadAffaire = Context.IsTheSame(_selectedAffaires, InfoAffaire);
            LoadAffaire.Completed += new EventHandler(IsTheSame_Completed);
        }
        private void IsTheSame_Completed(object sender, EventArgs e)
        {
            IsBusy = false;
            TexteInfo = "Succès : les données des affaires sélectionnées ont été chargée.";
            IEnumerable<Affaire> affaire = LoadAffaire.Value.AsEnumerable();
            MessageBox.Show(affaire.ElementAt(0).nom_fichier_pretour);
        }
