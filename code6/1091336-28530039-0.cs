       try
       {
            SignIn( UsernameTextBox.Text, PasswordTextBox.Text );
       }
       
       catch ( AuthenticationFailedException ex )
       {
            // Check for lockout. password expired etc.
       }
