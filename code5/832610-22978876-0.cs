    using System;
    using System.Windows.Forms;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    
    public partial class Main : Form
    {
    	private SpeechRecognitionEngine listener;
    	private SpeechSynthesizer speaker;		
    
    	public Main()
    	{
    		InitializeComponent();
    	}
    
    	private void Main_Load(object sender, EventArgs e)
    	{
    		speaker = new SpeechSynthesizer();
    		speaker.SelectVoice("Microsoft David Desktop");
    
    		GrammarBuilder builder = new GrammarBuilder();
    		builder.AppendDictation();
    
    		Grammar grammar = new Grammar(builder);
    		
    		listener = new SpeechRecognitionEngine();
    		listener.LoadGrammar(grammar);
    		listener.SetInputToDefaultAudioDevice();
    		listener.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(listener_SpeechRecognized);
    		listener.RecognizeAsync(RecognizeMode.Multiple);
    	}
    
    	void listener_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    	{
    		string commandName = e.Result.Text;
    		
    		switch (commandName.ToLower())
    		{
    			case "exit":
    
    				speaker.Speak("talk to you later, bye");
    				Application.Exit();
    				break;
    
    			case "stop speaking":
    			case "stop talking":
    			case "be quiet":
    			case "silence":
    
    				speaker.SpeakAsyncCancelAll();
    				break;
    
    			case "hello":
    
    				speaker.SpeakAsync("hello, how are you doing?");
    				break;
    
    			case "i'm fine":
    
    				speaker.SpeakAsync("i am glad to hear that");
    				break;
    
    			case "thank you":
    
    				speaker.SpeakAsync("you're welcome");
    				break;
    
    			case "thanks":
    
    				speaker.SpeakAsync("no problem");
    				break;
    
    			case "what's the time":
    			case "what time is it":
    			case "time":
    
    				speaker.SpeakAsync(DateTime.Now.ToShortTimeString());
    
    				break;
    
    			case "what's the date":
    			case "what day is it":
    			case "what is today's date":
    			case "what is today":
    			case "today":
    
    				speaker.SpeakAsync(DateTime.Today.ToString("dddd, MMMM d, yyyy"));
    
    				break;
    
    			case "do read it":
    
    				Process.Start("http://www.reddit.com");
    				break;
    
    			case "do face book":
    
    				Process.Start("http://www.facebook.com");
    				break;
    
    			case "do search":
    
    				Process.Start("http://www.google.com");
    				break;
    
    			case "do videos":
    
    				Process.Start("http://www.youtube.com");
    				break;
    
    			default:
    
    				//handle non-normalized recognition
    				Match m = Regex.Match(commandName, "YOUR_PATTERN_HERE");
    
    				if (m.Success)
    				{
    					speaker.SpeakAsync("I found a match");
    					
    					//example, probably should URL encode the value...
    					//Process.Start("http://www.google.com?q=" + m.Value);
    				}
    
    				break;
    		}
    	}
    
    	private void Main_FormClosing(object sender, FormClosingEventArgs e)
    	{
    		//be sure to clean up!
    		listener.UnloadAllGrammars();
    		listener.Dispose();
    		listener = null;
    		
    		speaker.Dispose();
    		speaker = null;
    
    		grammar = null;
    	}
    }
