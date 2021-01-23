            foreach (var rx in rxs)
            {
                StringByColumnViewModel svm = new StringByColumnViewModel();
                this.Saved +=  svm.OnSaved;
            }
