    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.Text;
    using System.Threading.Tasks;
    namespace j2associates.Tools.Winforms.Controls
    {
        [Designer(typeof(ContentPanel.Designer))]
        public class ContentPanel : Panel
        {
            private ScrollableControl _parentScrollableControl;
            public ContentPanel()
                : base()
            {
                // Dock is always fill.
                this.Dock = DockStyle.Fill;
            }
            protected override void OnParentChanged(EventArgs e)
            {
                base.OnParentChanged(e);
                if (this.Parent != null)
                {
                    Control parent = this.Parent;
                    while (parent != null && this.Parent.GetType() != typeof(ScrollableControl))
                    {
                        parent = parent.Parent;
                    }
                    if (parent != null && parent.GetType() == typeof(ScrollableControl))
                    {
                        _parentScrollableControl = (ScrollableControl)parent;
                        // Property value is retrieved from scrollable control panel.
                        this.AutoScroll = _parentScrollableControl.AutoScroll;
                    }
                }
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (_parentScrollableControl != null)
                {
                    this.AutoScroll = _parentScrollableControl.AutoScroll;
                }
            }
            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);
                this.AutoScroll = _parentScrollableControl != null ? _parentScrollableControl.AutoScroll : false;
            }
            #region Designer - Friend class
            /// <summary>
            /// Allows us to handle special cases at design time.
            /// </summary>
            internal class Designer : ParentControlDesigner
            {
                private IDesignerHost _designerHost = null;
                private Control _parent = null;
                #region Overrides
                #region Initialize
                public override void Initialize(IComponent component)
                {
                    base.Initialize(component);
                    // Used to determine whether the content panel is sited on a form or on a user control.
                    _designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
                    _parent = ((ContentPanel)component).Parent;
                }
                #endregion
                #region SelectionRules
                public override SelectionRules SelectionRules
                {
                    get
                    {
                        SelectionRules selectionRules = base.SelectionRules;
                        // When hosted on a form, remove all resizing and moving grips at design time
                        // because the content panel is part of a composed user control and it cannot
                        // be moved nor can the dock property change.
                        //
                        // When not hosted on a form, then it is part of a user control which is being
                        // composed and it can be moved or the dock property changed.
                        if (!ReferenceEquals(_designerHost.RootComponent, _parent))
                        {
                            selectionRules = SelectionRules.Visible | SelectionRules.Locked;
                        }
                        return selectionRules;
                    }
                }
                #endregion
                #region PreFilterProperties
                protected override void PreFilterProperties(System.Collections.IDictionary properties)
                {
                    base.PreFilterProperties(properties);
                    // The Anchor property is not valid for a ContentPanel so just get rid of it.
                    properties.Remove("Anchor");
                }
                #endregion
                #region PostFilterProperties
                protected override void PostFilterProperties(System.Collections.IDictionary properties)
                {
                    // Hide the Anchor property so it cannot be changed by the developer at design time.
                    PropertyDescriptor dockDescriptor = (PropertyDescriptor)properties["Dock"];
                    dockDescriptor = TypeDescriptor.CreateProperty(dockDescriptor.ComponentType, dockDescriptor, new Attribute[] { new BrowsableAttribute(false), new EditorBrowsableAttribute(EditorBrowsableState.Never)} );
                    properties[dockDescriptor.Name] = dockDescriptor;
                    // Hide the AutoScroll property so it cannot be changed by the developer at design time
                    // because it is set from the nearest panel of type scrollable control.
                    PropertyDescriptor autoScrollDescriptor = (PropertyDescriptor)properties["AutoScroll"];
                    autoScrollDescriptor = TypeDescriptor.CreateProperty(autoScrollDescriptor.ComponentType, autoScrollDescriptor, new Attribute[] { new ReadOnlyAttribute(true) });
                    properties[autoScrollDescriptor.Name] = autoScrollDescriptor;
                    // Make the Name property read only so it cannot be changed by the developer at design time
                    // because it is set from the nearest panel of type scrollable control.
                    PropertyDescriptor nameDescriptor = (PropertyDescriptor)properties["Name"];
                    nameDescriptor = TypeDescriptor.CreateProperty(nameDescriptor.ComponentType, nameDescriptor, new Attribute[] { new ReadOnlyAttribute(true) });
                    properties[nameDescriptor.Name] = nameDescriptor;
                    // Always call the base method last.
                    base.PostFilterProperties(properties);
                }
                #endregion
                #endregion
            }
            #endregion
        }
    }
