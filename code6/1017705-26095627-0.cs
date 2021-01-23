    private void Next_Click(object sender, RoutedEventArgs e){
      UpdateUI("Please wait for data retrieval", delegate() { someRandomTimeTakingMethod(); });
      this.footerText = "Ready";
    }
	public delegate void NoArgsDelegate();
    
	public void UpdateUI(string description, NoArgsDelegate operation)
		{
			this.FooterText= description;
			DispatcherFrame frame = new DispatcherFrame();
			DispatcherOperation dispatcherOperation = Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.ContextIdle, operation);
			dispatcherOperation.Completed += delegate(object sender, EventArgs e)
			{																					
				frame.Continue = false;	
			};
			Dispatcher.PushFrame(frame);
		}
