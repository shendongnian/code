    private void backgroundWorker_ProgressChanged( object sender , ProgressChangedEventArgs e )
        {
    
          this.UpdateOnMainThread(
            ( ) =>
            {
              wdgProgressBar.Value = e.ProgressPercentage;
              if ( this.Visible == false )
              {
                this.ShowDialog( );
                this.Update( );
              }
            } );
        }
    
        private void UpdateOnMainThread( Action action )
        {
          if ( this.InvokeRequired )
          {
            this.BeginInvoke( ( MethodInvoker ) action.Invoke);
          }
          else
          {
            action.Invoke( );
          }
        }
    
        private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e )
        {
          this.UpdateOnMainThread(
            ( ) =>
            {
              this.Hide( ); //Here I get a InvalidOperationException
              this.Dispose( );
            } );
    
        }
