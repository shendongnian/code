    public class CustomGrid : Grid
    {        
        /// <summary>
        /// Rows Auto
        /// </summary>
        public string RowsAuto
        {
            get { return (string)GetValue(RowsAutoProperty); }
            set { SetValue(RowsAutoProperty, value); }
        }
        public static readonly DependencyProperty RowsAutoProperty = DependencyProperty.Register(
            "RowsAuto", typeof(string), typeof(CustomGrid), new PropertyMetadata(RowsAuto_PropertyChangedCallback));
        private static void RowsAuto_PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as CustomGrid;
            if (d != null)
                grid.RowDefinitions.ManiRows(e.NewValue as string);            
        }
        public static String GetRowsAuto(UIElement element)
        {
            if (element == null)
            {
                new ArgumentNullException("element");
            }
            return (string)element.GetValue(RowsAutoProperty);
        }
        public static void SetRowsAuto(UIElement element, String value)
        {
            if (element == null)
            {
                new ArgumentNullException("element");
            }
            element.SetValue(RowsAutoProperty, value);
        }
    }
    public static class DefinitionExtensions
    {
        public static void ManiRows(this RowDefinitionCollection rowDef, string format)
        {
            if (rowDef == null)
                throw new NullReferenceException("rowDef nust not be null");
            rowDef.Clear();
            if (string.IsNullOrWhiteSpace(format))
                return;
            string[] value = format.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in value)
            {
                if (item.Contains("auto"))
                {
                    RowDefinition cd = new RowDefinition()
                    {
                        Height = new GridLength(1, GridUnitType.Auto)
                    };
                    rowDef.Add(cd);
                }
                else if (item.Equals("*"))
                {
                    RowDefinition cd = new RowDefinition()
                    {
                        Height = new GridLength(1, GridUnitType.Star)
                    };
                    rowDef.Add(cd);
                }
                else if (item.EndsWith("*"))
                {
                    double length;
                    if (double.TryParse(item.Substring(0,item.Length-1),out length))
                    {
                        RowDefinition cd = new RowDefinition()
                        {
                            Height = new GridLength(length, GridUnitType.Star)
                        };
                        rowDef.Add(cd);
                    }
                }
                else
                {
                    RowDefinition cd = new RowDefinition()
                    {
                        Height = new GridLength(double.Parse(item))
                    };
                    rowDef.Add(cd);
                }
            }
        }
    }
