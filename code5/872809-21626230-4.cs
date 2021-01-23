          namespace WpfApplication
          {
            using System;
            using System.Windows;
            using System.Windows.Input;
            
            /// <summary>
            /// Checks the user credentials.
            /// </summary>
            public class LoginCommand : ICommand
            {
               /// <summary>
               /// Defines the method to be called when the command is invoked.
               /// </summary>
               /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
               public void Execute(object parameter)
               {
                  MainWindowViewModel viewModel = parameter as MainWindowViewModel;
    
                  if (viewModel == null)
                  {
                     return;
                  }
    
                  if (viewModel.Name == "ep" && viewModel.Password == "pass")
                  {
                     MessageBox.Show("namd and Pw accepted");
    
                     //open new page
                     var HomeScreen = new HomeScreen();
                     HomeScreen.Show();
                  }
                  else
                  {
                     //deny access
                     MessageBox.Show("Incorrect username and password");
                  }
               }
    
               /// <summary>
               /// Defines the method that determines whether the command can execute in its current state.
               /// </summary>
               /// <returns>
               /// true if this command can be executed; otherwise, false.
               /// </returns>
               /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
               public bool CanExecute(object parameter)
               {
                  // Update this for your application's needs.
                  return true;
               }
    
               public event EventHandler CanExecuteChanged;
            }
         }
