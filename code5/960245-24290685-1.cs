     public void NavigateToViewByChannelPage(Channel parameter)
            {
                //Must create an instance so that the page can recieve the info
    Needed this -->  SimpleIoc.Default.GetInstance<ViewByChannelPageViewModel>();
        
                //Sending info to ViewModel
                _messenger.Send(new IdParameter() {Id = parameter.Id});
                
                //Going to page
                this.Navigate(typeof(ViewByChannelPage));
            }
