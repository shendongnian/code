            button.Click += (sender, args) =>
                {
                    var intent = new Intent(this, typeof(Results));
                    intent.PutExtra("cbs", new[] { cb1.Checked, cb2.Checked, cb3.Checked, cb4.Checked });
                    intent.PutExtra("texts", new[] { cb1.Text, cb2.Text, cb3.Text, cb4.Text });
                    this.StartActivity(intent);
                };
        }
    }
    [Activity(Label = "Results", MainLauncher = false, Icon = "@drawable/icon")]
    public class Results : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var cbs = this.Intent.Extras.GetBooleanArray("cbs");
            var texts = this.Intent.Extras.GetStringArray("texts");
            foreach (var cb in cbs)
            {
                System.Diagnostics.Debug.WriteLine(cb);
            }
            foreach (var text in texts)
            {
                System.Diagnostics.Debug.WriteLine(text);
            }
            
        }
    }
