    using Android.Content;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.OS;
    
    namespace ToolbarSample
    {
        [Activity(Label = "ToolbarSample", MainLauncher = true, Icon = "@drawable/icon")]
        public class MainActivity : Activity
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                // Get our button from the layout resource,
                // and attach an event to it
                Button button = FindViewById<Button>(Resource.Id.button);
    
                if (button != null)
                {
                    button.Click += delegate
                    {
                            button.Enabled = false;
    
                            string content = "Jason rules";
                            string filename = "file.txt";
    
                            var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                            if (!Directory.Exists(documents))
                            {
                                Console.WriteLine("Directory does not exist.");
                            }
                            else
                            {
                                Console.WriteLine("Directory exists.");
    
                                File.WriteAllText(documents + @"/" + filename, content);
    
                                if (!File.Exists(documents + @"/" + filename))
                                {
                                    Console.WriteLine("Document not found.");
                                }
                                else
                                {
                                    string newContent = File.ReadAllText(documents + @"/" + filename);
    
                                    TextView viewer = FindViewById<TextView>(Resource.Id.textView1);
                                    if (viewer != null)
                                    {
                                        viewer.Text = newContent;
                                    }
                                }
                            }
                    };
                }
            }
        }
    }
