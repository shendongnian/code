        static void Main(string[] args)
        {
            String str = "<Run FontWeight=\"Bold\" Foreground=\"#FF0000FF\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xml:space=\"preserve\"><Run.TextDecorations><TextDecoration Location=\"Underline\" /></Run.TextDecorations>046/98 5802007513 \r</Run>";
            
            try
            {
                var temp = XamlReader.Parse(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
