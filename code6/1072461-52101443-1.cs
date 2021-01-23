            protected override bool OnBackButtonPressed()
            {
                try
                {
                    var lastPage = navigationStack.Pop();
                    if (lastPage.Equals(Detail))
                        lastPage = navigationStack.Pop();
                    Detail = (Page)lastPage;
                    IsPresented = false;
                    
                   // to avoid app close when complete pop and new page is push on top of it 
                    if (navigationStack.Count == 0) 
                        navigationStack.Push(Detail);
                    return true;
                }
                catch (Exception)
                {
    
                    return base.OnBackButtonPressed();
                }
            }
