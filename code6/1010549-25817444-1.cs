    protected void Button_Click( object sender , EventArgs e )
    {
      string           userName  = Name_id.Text ;
      string           emailAddr = Email_id.Text ;
      ValidationStatus status    = ValidateUser( userName , emailAddr ) ;
      switch ( status )
      {
      case ValidationStatus.Valid         :
        Label1.Text = "" ;
        break ;
      case ValidationStatus.EmailInUse    :
        Label1.Text = "Email address in use" ;
        break ;
      case ValidationStatus.UserNameInUse :
        Label1.Text = "User name in use" ;
        break ;
      case ValidationStatus.EmailInUse|ValidationStatus.UserNameInUse:
        Label1.Text = "Both user name and email address in use." ;
        break ;
      default :
        throw new InvalidOperationException() ;
      }
      
      if ( status == ValidationStatus.Valid )
      {
        CreateNewUser() ;
      }
    }
