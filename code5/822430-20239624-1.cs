    public RelayCommand Click_command
    {
          get
          {
              if (this.click_command == null)
              {
                    this.click_command = new RelayCommand<MouseButtonEventArgs>((args) => this.Execute_me(args));
              }
              return this.click_command;
          }
    }
