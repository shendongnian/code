    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsLayoutButton
    {
        class FlowLayoutButton : System.Windows.Forms.Button
        {
            public FlowLayoutButton()
            {
                Label labelLeft = new Label();
                labelLeft.Text = "12345478";
                labelLeft.Dock = DockStyle.Fill;
                labelLeft.TextAlign = ContentAlignment.MiddleCenter;
    
                TableLayoutPanel horizontalLayout = new TableLayoutPanel();
                horizontalLayout.Dock = DockStyle.Fill;
                horizontalLayout.ColumnCount = 2;
                horizontalLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
                horizontalLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
                horizontalLayout.Controls.Add(labelLeft, 0, 0);
                horizontalLayout.BackColor = Color.FromArgb(0, 0, 0, 0);
    
                Label labelTop = new Label();
                labelTop.Text = "Some Information";
                labelTop.Dock = DockStyle.Fill;
                labelTop.TextAlign = ContentAlignment.MiddleCenter;
    
                Label labelBottom = new Label();
                labelBottom.Text = "Date";
                labelBottom.Dock = DockStyle.Fill;
                labelBottom.TextAlign = ContentAlignment.MiddleCenter;
    
                TableLayoutPanel verticalLayout = new TableLayoutPanel();
                verticalLayout.Dock = DockStyle.Fill;
                verticalLayout.RowCount = 2;
                verticalLayout.RowStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
                verticalLayout.RowStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
                verticalLayout.Controls.Add(labelTop, 0, 0);
                verticalLayout.Controls.Add(labelBottom, 0, 1);
    
                horizontalLayout.Controls.Add(verticalLayout, 1, 0);
    
                this.Controls.Add(horizontalLayout);
    
                Control[] controls = new Control[] { horizontalLayout, verticalLayout, labelLeft, labelTop, labelBottom };
                forEachControl(controls, (control) => { control.Click += (sender, e) => { this.OnClick(e); }; });
                forEachControl(controls, (control) => { control.MouseDown += (sender, e) => { this.OnMouseDown(e); }; });
                forEachControl(controls, (control) => { control.MouseUp += (sender, e) => { this.OnMouseUp(e); }; });
                forEachControl(controls, (control) => { control.MouseEnter += (sender, e) => { this.OnMouseEnter(e); }; });
                forEachControl(controls, (control) => { control.MouseLeave += (sender, e) => { this.OnMouseLeave(e); }; });
                forEachControl(controls, (control) => { control.Enter += (sender, e) => { this.OnEnter(e); }; });
                forEachControl(controls, (control) => { control.Leave += (sender, e) => { this.OnLeave(e); }; });
                forEachControl(controls, (control) => { control.GotFocus += (sender, e) => { this.OnGotFocus(e); }; });
                forEachControl(controls, (control) => { control.LostFocus += (sender, e) => { this.OnLostFocus(e); }; });
                forEachControl(controls, (control) => { control.KeyPress += (sender, e) => { this.OnKeyPress(e); }; });
                forEachControl(controls, (control) => { control.KeyDown += (sender, e) => { this.OnKeyDown(e); }; });
                forEachControl(controls, (control) => { control.KeyUp += (sender, e) => { this.OnKeyUp(e); }; });
                forEachControl(controls, (control) => { control.MouseClick += (sender, e) => { this.OnMouseClick(e); }; });
                forEachControl(controls, (control) => { control.MouseDoubleClick += (sender, e) => { this.OnMouseDoubleClick(e); }; });
            }
    
            private void forEachControl(Control[] controls, Action<Control> action)
            {
                foreach(Control control in controls) { action(control); }
            }
        }
    }
