    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    namespace System.Windows.Controls {
    
        [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
        public partial class ToolStripDateTimePicker : DesignerToolStripControlHost, IComponent {
            public ToolStripDateTimePicker() : base(new DateTimePicker() { Margin = new Padding(0, 0, 0, 0), Width = 150, Value = DateTime.Now.Date }) { }
            #region Properties
            [Browsable(true)]
            [Category("Design")]
            [Description("Internal ToolStrip hosted control.")]
            public DateTimePicker DateTimePickerControl { get { return Control as DateTimePicker; } }
        
            [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
            [Category("Behavior")]
            [Description("Gets or sets the tab order of the control within its container.")]
            public int TabIndex { get { return DateTimePickerControl.TabIndex; } set { DateTimePickerControl.TabIndex = value; } }
            [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
            [Category("Behavior")]
            [Description("Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.")]
            public bool TabStop { get { return DateTimePickerControl.TabStop; } set { DateTimePickerControl.TabStop = value; } }
            [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
            [Description("This property is ignored.")]
            public override string Text { get { return DateTimePickerControl.Value.ToString(); } set { DateTimePickerControl.Value = DateTime.Parse(value); } }
            [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
            [Category("Behavior")]
            [Description("The current date/time value for this control.")]
            public DateTime Value { get { return DateTimePickerControl.Value; } set { DateTimePickerControl.Value = value; } }
            #endregion
            #region Events
            [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
            [Category("Focus")]
            [Description("Occurs when the input focus enters the control.")]
            public new EventHandler Enter;
            [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
            [Category("Focus")]
            [Description("Occurs when the input focus leaves the control.")]
            public new EventHandler Leave;
            [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
            [Category("Behavior")]
            [Description("Occurs when the value of the control changes.")]
            public event EventHandler ValueChanged;
            #endregion
            #region Event Handlers
            protected void OnEnter(object sender, EventArgs e) { EventHandler handler = Enter; if (handler != null) handler(this, e); }
            protected void OnLeave(object sender, EventArgs e) { EventHandler handler = Leave; if (handler != null) handler(this, e); }
            protected override void OnGotFocus(EventArgs e) {
                base.OnGotFocus(e);
                if (Enter != null) {
                    if (DateTime.Now.Ticks - _FocusGlitchFix_LastEvent > _FocusGlitchFixTickWindow) Enter.Invoke(this, e);
                    _FocusGlitchFix_LastEvent = DateTime.Now.Ticks;
                }
            }
            protected override void OnLostFocus(EventArgs e) {
                base.OnLostFocus(e);
                if (Leave != null) {
                    if (DateTime.Now.Ticks - _FocusGlitchFix_LastEvent > _FocusGlitchFixTickWindow) Leave.Invoke(this, e);
                    _FocusGlitchFix_LastEvent = DateTime.Now.Ticks;
                }
            }
            protected void OnValueChanged(object sender, EventArgs e) { EventHandler handler = ValueChanged; if (handler != null) handler(this, e); }
            protected override void OnSubscribeControlEvents(Control control) {
                base.OnSubscribeControlEvents(control);
                DateTimePickerControl.ValueChanged += new EventHandler(OnValueChanged);
            }
            protected override void OnUnsubscribeControlEvents(Control control) {
                base.OnUnsubscribeControlEvents(control);
                DateTimePickerControl.ValueChanged -= new EventHandler(OnValueChanged);
            }
            #endregion
            #region Focus Glitch Workaround data
            private long _FocusGlitchFix_LastEvent = 0;
            private readonly long _FocusGlitchFixTickWindow = 100000; // 10ms
        
            #endregion
        }
    }
