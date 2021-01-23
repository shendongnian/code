        public void ShowPrompt()
        {            
            this.PromptWindow = ObjectFactory.GetInstance<IPromptWindowViewModel>().Window as ModernWindow;
            this.PromptWindow.Title = string.Concat("Control ", this.PromptOriginsEntity.PromptOriginsIdentity);
            this.PromptWindow.Tag = this.PromptOriginsEntity.PromptOriginsIdentity;
            this.PromptWindow.Owner = Application.Current.MainWindow;
            // Store Window object in PromptWindowsCollection
            this.PWPMainViewModel.PromptWindowsCollection.Add(this.PromptWindow);
            this.PromptWindow.Show(); // inorder to retrieve the ModernFrame the ModernWindow is to be shown first
            ModernFrame frameContent = (ModernFrame)this.PromptWindow.Template.FindName("ContentFrame", this.PromptWindow);
            UserControl userControl = new UserControl { Content = GetView<IPromptViewModel>(), Tag = this.PromptOriginsEntity.PromptOriginsIdentity };
            frameContent.Content = userControl;
            this.PWPMainViewModel.PromptsCollection.Add(userControl);
            IPromptViewModel promptViewModel = (IPromptViewModel)((IView)userControl.Content).DataContext;
            promptViewModel.PromptEntity.Identity = this.PromptOriginsEntity.PromptOriginsIdentity;
        }
