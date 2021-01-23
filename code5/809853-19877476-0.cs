       public class ViewModelDealDetails: BindableBase
        {
            private Deal selectedDeal;
    
            public Deal SelectedDeal
            {
                get { return selectedDeal; }
                set { SetProperty(ref selectedDeal, value); }
            }
            
        }
    
        public class Deal: BindableBase
        {
            private string title;
    
            public string Title
            {
                get { return title; }
                set { SetProperty(ref title, value); }
            }
        }
