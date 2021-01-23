    [TemplatePart(Name = "PART_leftButton", Type = typeof(Button))]
    public class CustomControl1 : Control
    {
        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var button = Template.FindName("PART_leftButton", this) as Button;
            if (button != null)
            {
                button.Click += (s, a) => Console.WriteLine(@"click");
            }
        }
    }
