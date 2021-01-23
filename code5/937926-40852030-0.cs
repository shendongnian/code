            MessageBoxResult Exit = MessageBox.Show("Do You Want To Exit?", "Attention !!!", MessageBoxButton.OKCancel);
            if (Exit == MessageBoxResult.OK)
            {
                Application.Current.Terminate(); //Terminates App    
            }
            else if (Exit == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
