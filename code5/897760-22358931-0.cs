            this.URIs = new stem.Collections.ObjectModel.ObservableCollection<URIPairing>();
             this.URIs.Add(new URIPairing("DEV", "Some URL"));
            this.URIs.Add(new URIPairing("SANDBOX", "Some URL"));
            this.URIs.Add(new URIPairing("QA", "Some URI"));
            URICombo.ItemsSource = URIs;
            URICombo.DisplayMemberPath = "Name";
