    public class MyTextBlock:TextBlock
    {
        private DependencyPropertyDescriptor _descriptor;
        private bool _isUpdating;
        public MyTextBlock()
        {
            this.Unloaded += OnUnloaded;
            _descriptor = DependencyPropertyDescriptor.FromProperty(TextProperty, typeof(TextBlock));
            _descriptor.AddValueChanged(this, OnValueChanged);
        }
        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            if(_isUpdating) return;
            _isUpdating = true;
            var text = Text;
            if(string.IsNullOrEmpty(text)) return;
            Inlines.Clear();
            UpdateInlines(text);
            _isUpdating = false;
        }
        private void UpdateInlines(string text)
        {
            //text = @"{Customer.Panel.field}";
            var runs = new List<Run>();
            var sb = new StringBuilder();
            foreach (var current in text)
            {
                if (current.Equals('}') || current.Equals('{'))
                {
                    if (sb.Length == 0)
                    {
                        runs.Add(new Run
                        {
                            Text = current.ToString()
                        });
                    }
                    else
                    {
                        runs.Add(new Run
                        {
                            Text = sb.ToString(),
                            Foreground = Brushes.Red
                        });
                        runs.Add(new Run
                        {
                            Text = current.ToString()
                        });
                        sb.Clear();
                    }
                }
                else
                {
                    sb.Append(current);
                }
            }
            if(sb.Length > 0)
                runs.Add(new Run{Text = sb.ToString(), Foreground = Brushes.Red});
            runs.ForEach(run => 
                Inlines.Add(run));
        }
        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Unloaded -= OnUnloaded;
            _descriptor.RemoveValueChanged(this, OnValueChanged);
        }
    }
