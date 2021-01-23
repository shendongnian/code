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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MyComboProperties
    {
        private string _MySourceQuery;
        private string _MyDisplayMember;
        private string _MyValueMember;
        public MyComboProperties()
        {
        }
        [Category("MyComboBoxProperties")]
        [DisplayName("MySourceQuery")]
        [Description("MySourceQuery")]
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
    }
