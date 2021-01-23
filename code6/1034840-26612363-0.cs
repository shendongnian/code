    using System.Threading.Tasks;
	namespace System.Diagnostics
	{
		public class ProcessEventArgs : EventArgs
		{
			public Process Process { get; protected set; }
			
			public ProcessEventArgs( Process process )
			{
				this.Process = process;
			}
		}
		public delegate void ProcessNotRespondingEvent( object sender, ProcessEventArgs e );
		public class ProcessMonitor
		{
			public event ProcessNotRespondingEvent NotResponding;
			
			protected Process mProcess;
			
			public ProcessMonitor( Process process )
			{
				this.mProcess = process;
			}
			
			public async void Start()
			{
				Task t = null;
				t = Task.Run( () =>
				{
					while( this.mProcess.Responding )
						t.Wait( 1000 ); //1 second
					
					this.OnNotResponding();
				} );
				
				await t;
			}
			
			protected void OnNotResponding()
			{
				if( this.NotResponding == null )
					return;
				
				ProcessEventArgs e = new ProcessEventArgs( this.mProcess );
				this.NotResponding( this, e );
			}
		}
	}
