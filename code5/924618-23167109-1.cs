    public class MyEnumEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        private bool _cancel;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            ListBox listBox = new ListBox();
            listBox.DisplayMember = "Name"; // EnumItem 'Name' property
            listBox.IntegralHeight = true;
            listBox.SelectionMode = SelectionMode.One;
            listBox.MouseClick += OnListBoxMouseClick;
            listBox.KeyDown += OnListBoxKeyDown;
            listBox.PreviewKeyDown += OnListBoxPreviewKeyDown;
            Type enumType = value.GetType();
            if (!enumType.IsEnum)
                throw new InvalidOperationException();
            foreach (FieldInfo fi in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                EnumItem item = new EnumItem();
                item.Value = fi.GetValue(null);
                object[] atts = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (atts != null && atts.Length > 0)
                {
                    item.Name = ((DescriptionAttribute)atts[0]).Description;
                }
                else
                {
                    item.Name = fi.Name;
                }
                int index = listBox.Items.Add(item);
                if (fi.Name == value.ToString())
                {
                    listBox.SetSelected(index, true);
                }
            }
            _cancel = false;
            _editorService.DropDownControl(listBox);
            if (_cancel || listBox.SelectedIndices.Count == 0)
                return value;
            return ((EnumItem)listBox.SelectedItem).Value;
        }
        private class EnumItem
        {
            public object Value { get; set; }
            public string Name { get; set; }
        }
        private void OnListBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _cancel = true;
                _editorService.CloseDropDown();
            }
        }
        private void OnListBoxMouseClick(object sender, MouseEventArgs e)
        {
            int index = ((ListBox)sender).IndexFromPoint(e.Location);
            if (index >= 0)
            {
                _editorService.CloseDropDown();
            }
        }
        private void OnListBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _editorService.CloseDropDown();
            }
        }
    }
    public class MyEnumConverter<TEnum> : TypeConverter where TEnum : struct
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string svalue = string.Format(culture, "{0}", value);
            TEnum e;
            if (Enum.TryParse(svalue, out e))
                return e;
            foreach (FieldInfo fi in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                object[] atts = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (atts != null && atts.Length > 0)
                {
                    if (string.Compare(((DescriptionAttribute)atts[0]).Description, svalue, StringComparison.OrdinalIgnoreCase) == 0)
                        return fi.GetValue(null);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                string svalue = string.Format(culture, "{0}", value);
                foreach (FieldInfo fi in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    object[] atts = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (atts != null && atts.Length > 0)
                    {
                        if (string.Compare(fi.Name, svalue, StringComparison.OrdinalIgnoreCase) == 0)
                            return ((DescriptionAttribute)atts[0]).Description;
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
