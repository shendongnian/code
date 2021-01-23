    	void Main()
	{
			DumpThread("Main UI");
			Application.Run(new Form1());
		}
	
		public static void DumpThread(string msg) {
			Console.WriteLine(string.Format(msg + " thread id : ({0})",Thread.CurrentThread.ManagedThreadId));
		}
		
		public class Form1 : Form
		{
			private Label[] _lights = Enumerable.Range(1,4).Select (i => new Label() { Left = 100 + ((i-1) *25), Top = 90, Text=i.ToString(), BackColor = Color.Green, Width=20, Visible = true }).ToArray();
			private Label _threadLabel = new Label() { Left = 20, Top = 90, Text="Steps", Width = 50 };
			private TextBox _textbox = new TextBox() { Left = 100,  Top = 120, Text = "blah blah" };	
			private Label _label = new Label() { Left = 20, Top = 120, Text="Label" };
			private Button _button = new Button() { Left = 20, Top = 150, Width = 250,  Text = "Nested Tasks + Delay && ContinueWith" };
			private Button _button2 = new Button() { Left = 20, Top = 180, Width = 250,  Text = "bground monitor Task + final ContinueWith" };
			private Button _button3 = new Button() { Left = 20, Top = 210, Width = 250,  Text = "async && await (.net 4.5)" };		
			
			public Form1()
			{
				InitialiseControls();
				DumpThread("Form initialisation");
				
				// Task & ContinueWith
				// ********************
				// very nested continuations are hard to test or debug in more complex scenarios, 
				// considering the code below is a super simple contrived example and it's already not easy to read!
				_button.Click+= delegate 
				{ 
					Heading(_button.Text);			
					DumpThread("Code behind outter");
						Buttons(Enabled:false);
						// simulate long running task followed by UI update
						Task.Delay(500).ContinueWith(ant0 => 
						{ 
							DumpThread("continuation 1");
							_lights[0].Visible = true; 
							Task.Delay(500).ContinueWith( ant1 => 
							{
								DumpThread("continuation 2");
								_lights[1].Visible = true; 
								Task.Delay(500).ContinueWith( ant2 => 
								{
									DumpThread("continuation 3");
									_lights[2].Visible = true; 
									Task.Delay(500).ContinueWith( ant3 => 
									{
										DumpThread("continuation 4");								
										_lights[3].Visible = true; 
											Task.Delay(500).ContinueWith( ant4 => 
											{
												foreach(var light in _lights) light.Visible = false;
												Buttons(Enabled:true);
											},TaskScheduler.FromCurrentSynchronizationContext());
									},TaskScheduler.FromCurrentSynchronizationContext());
								},TaskScheduler.FromCurrentSynchronizationContext());
							},TaskScheduler.FromCurrentSynchronizationContext());
						},TaskScheduler.FromCurrentSynchronizationContext());		
				};
	
				// ignoring the fact that we could simply foreach(var light in _lights) 
				// done this way in order to help us compare "appending" different blocks of code vs ContinueWith
				
				
				// bground Task && no continue with's
				// **********************************
				// traditional means of keeping UI responsive, create a background thread, ensure updates run on control creator's thread
				_button2.Click+= delegate 
				{
					Heading(_button2.Text);
					DumpThread("code behind thread");
					Buttons(Enabled:false);
					Task.Run(()=> {
						DumpThread("monitoring thread");
						Thread.Sleep(500); 
						InvokeOnUIThread(_lights[0],l=> { l.Visible = true; DumpThread("Invoker 1");} );
						Thread.Sleep(500); 
						InvokeOnUIThread(_lights[1],l=> { l.Visible = true; DumpThread("Invoker 2");} );
						Thread.Sleep(500); 
						InvokeOnUIThread(_lights[2],l=> { l.Visible = true; DumpThread("Invoker 3");} );
						Thread.Sleep(500); 
						InvokeOnUIThread(_lights[3],l=> { l.Visible = true; DumpThread("Invoker 4");} );
						Thread.Sleep(500); 
						InvokeOnUIThread(_lights[3],l=> { 
							Buttons(Enabled:true);
							foreach(Label light in _lights) light.Visible = false;
						} );
						// finally
					});
				};			
				
				_button3.Click+=async delegate 
				{
					Heading(_button3.Text);
					DumpThread("codebehind");
					Buttons(Enabled:false);
					
					DumpThread("async step 1");	
					_lights[0].Visible = true; 
					await Task.Delay(500);
					
					DumpThread("async step 2");	
					_lights[1].Visible = true; 
					await Task.Delay(500);
					
					DumpThread("async step 3");
					_lights[2].Visible = true; 
					await Task.Delay(500);
					
					DumpThread("async step 4");	
					_lights[3].Visible = true; 
					await Task.Delay(500);
		
					Buttons(Enabled:true);
					foreach(Label light in _lights) light.Visible = false;				
				};
				
			}		
			
			// allow us to invoke a method on the control's UI threads (the thread that created the control)
			private delegate void Invoker(Control control);
			private void InvokeOnUIThread(Control control, Action<Control> action)
			{
				if (!this.InvokeRequired) action(control);
				control.Invoke(new Invoker(action),control);
			}
			
			private void Buttons(bool Enabled) {
				_button.Enabled = Enabled;
				_button2.Enabled = Enabled;
				_button3.Enabled = Enabled;
			}
			
			void InitialiseControls()
			{
				//this.SuspendLayout();
				Controls.AddRange(_lights);
				Controls.AddRange(new Control[] {_threadLabel, _button, _textbox, _label,_button2, _button3 });			
				foreach(var l in _lights) l.Visible = false;
				//this.ResumeLayout();
			}	
		
			private void Heading(string heading) {
				Console.WriteLine();
				Console.WriteLine(heading);
				Console.WriteLine("---------------");
			}
			
		}
