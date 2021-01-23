         void viewModel_PropertyChanged(object sender,PropertyChangedEventArgs e)
            {
            
            if (e.PropertyName == “MainBackGroundImage”)
            {
                  this.MainPanorama.UpdateLayout();
            }
            }
    
