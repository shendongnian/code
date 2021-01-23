	using System;
	using System.Collections.Concurrent;
	using System.ComponentModel;
	using System.IO;
	using System.Threading;
	using System.Windows.Forms;
	namespace Quest.Core.IO
	{
		public class ConcurrentStreamWriter : StreamWriter
		{
			private ConcurrentQueue<String> _stringQueue = new ConcurrentQueue<String>();
			private Boolean _disposing;
			private RichTextBox _textBox;
			public ConcurrentStreamWriter( Stream stream )
				: base( stream )
			{
				CreateQueueListener();
			}
			public ConcurrentStreamWriter( Stream stream, RichTextBox textBox )
				: this( stream )
			{
				_textBox = textBox;
			}
			public override void WriteLine()
			{
				base.WriteLine();
				_stringQueue.Enqueue( Environment.NewLine );
			}
			public override void WriteLine( string value )
			{
				base.WriteLine( value );
				_stringQueue.Enqueue( String.Format( "{0}\n", value ) );
			}
			public override void Write( string value )
			{
				base.Write( value );
				_stringQueue.Enqueue( value );
			}
			protected override void Dispose( bool disposing )
			{
				base.Dispose( disposing );
				_disposing = disposing;
			}
			private void CreateQueueListener()
			{
				var bw = new BackgroundWorker();
				bw.DoWork += ( sender, args ) =>
				{
					while ( !_disposing )
					{
						if ( _stringQueue.Count > 0 )
						{
							string value = string.Empty;
							if ( _stringQueue.TryDequeue( out value ) )
							{
								if ( _textBox != null )
								{
									if ( _textBox.InvokeRequired )
									{
										_textBox.Invoke( new Action( () =>
										{
											_textBox.AppendText( value );
											_textBox.ScrollToCaret();
										} ) );
									}
									else
									{
										_textBox.AppendText( value );
										_textBox.ScrollToCaret();
									}
								}
							}
						}
					}
				};
				bw.RunWorkerAsync();
			}
		}
	}
