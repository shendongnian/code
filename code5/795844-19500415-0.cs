    public class Version : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return System.Reflection.Assembly
                         .GetExecutingAssembly().GetName().Version.ToString();
        }
    }
