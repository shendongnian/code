        private void UpdateDataContextOfSeries()
        {
            onApplyTemplateFinished = false;
              
            //ADDED CODE STARTS
            if(this.Series != null)
            {
            //ADDED CODE ENDS
            foreach (var newItem in this.Series)
            {
                if (newItem is FrameworkElement)
                {
                    (newItem as FrameworkElement).DataContext = this.DataContext;
                }
            }
            onApplyTemplateFinished = true;
            UpdateSeries();            
            //ADDED CODE STARTS
            }
            //ADDED CODE ENDS
        }    
