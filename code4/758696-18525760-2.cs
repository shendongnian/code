            using System;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.Diagnostics;
            using System.Linq;
            using System.Text;
            using System.Drawing;
            using System.Globalization;
            namespace ExpandableMultiValuedCustomControl
            {
                public partial class MyComboBox : System.Windows.Forms.ComboBox
                {
                    private MyComboProperties _comboProperties = new MyComboProperties();
                    public MyComboBox()
                    {
                        InitializeComponent();
                    }
                    public MyComboBox(IContainer container)
                    {
                        container.Add(this);
                        InitializeComponent();
                    }
                    [Category("My Combo Properties")]
                    [DisplayName("My Combo Properties")]
                    [Description("My Combo Properties")]
                    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
                    public MyComboProperties MyComboProperties
                    {
                        get
                        {
                            return _comboProperties;
                        }
                        set
                        {
                            _comboProperties = value;
                        }
                    }
                }
                [DisplayName("My Combo Properties")]
                [Description("CMy Combo Properties")]
                [DefaultProperty("Text")]
                [DesignerCategory("Component")]
                [TypeConverter(typeof(ComboColorsTypeConverter))]
                public class MyComboProperties
                {
                    private string _MySourceQuery = "MySourceQuery";
                    private string _MyDisplayMember = "MyDisplayMember";
                    private string _MyValueMember = "MyValueMember";
                    public MyComboProperties()
                    {
                    }
                    [Category("MyComboBoxProperties")]
                    [DisplayName("MySourceQuery")]
                    [Description("MySourceQuery")]
                    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
                    public string MySourceQuery
                    {
                        get
                        {
                            return _MySourceQuery;
                        }
                        set
                        {
                            _MySourceQuery = value;
                        }
                    }
                    [Category("MyComboBoxProperties")]
                    [DisplayName("MyDisplayMember")]
                    [Description("MyDisplayMember")]
                    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
                    public string MyDisplayMember
                    {
                        get
                        {
                            return _MyDisplayMember;
                        }
                        set
                        {
                            _MyDisplayMember = value;
                        }
                    }
                    [Category("MyComboBoxProperties")]
                    [DisplayName("MyValueMember")]
                    [Description("MyValueMember")]
                    [DefaultValue(typeof(Color), "Yellow")]
                    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
                    public string MyValueMember
                    {
                        get
                        {
                            return _MyValueMember;
                        }
                        set
                        {
                            _MyValueMember = value;
                        }
                    }
                }
                public class ComboColorsTypeConverter : ExpandableObjectConverter//TypeConverter
                {
                    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
                    {
                        if (destinationType == typeof(MyComboProperties))
                        {
                            return true;
                        }
                        return base.CanConvertTo(context, destinationType);
                    }
                    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
                    {
                        if (destinationType == typeof(String) && value is MyComboProperties)
                        {
                            MyComboProperties _comboProperties = (MyComboProperties)value;
                            return _comboProperties.MyDisplayMember.ToString() + "; " + _comboProperties.MySourceQuery.ToString() + "; " + _comboProperties.MyValueMember.ToString();
                        }
                        return base.ConvertTo(context, culture, value, destinationType);
                    }
                    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
                    {
                        if (sourceType == typeof(string))
                        {
                            return true;
                        }
                        return base.CanConvertFrom(context, sourceType);
                    }
                    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
                    {
                        if (value is string)
                        {
                            MyComboProperties _comboProperties = new MyComboProperties();
                            string strExtractData = (string)value;
                            string strDisplayMember = strExtractData.Substring(strExtractData.IndexOf(";") + 1, strExtractData.Length).Trim();
                            string strSourceQuery = strExtractData.Substring(strExtractData.IndexOf(";") + 1, strExtractData.Length).Trim();
                            string strValueMember = strExtractData.Substring(strExtractData.IndexOf(";") + 1, strExtractData.Length).Trim();
                            _comboProperties.MyDisplayMember = strDisplayMember;
                            _comboProperties.MySourceQuery = strSourceQuery;
                            _comboProperties.MyValueMember = strValueMember;
                            return _comboProperties;
                        }
                        return base.ConvertFrom(context, culture, value);
                    }
                }
            }
