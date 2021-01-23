       using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SmartDeviceProject3
    {
        public partial class Form1 : Form
        {
    
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
            private System.Windows.Forms.MainMenu mainMenu1;
            private TreeViewEx treeView1;
    
            public Form1()
            {
                this.mainMenu1 = new System.Windows.Forms.MainMenu();
                this.treeView1 = new TreeViewEx();
    
                this.SuspendLayout();
                this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.treeView1.Location = new System.Drawing.Point(0, 0);
                this.treeView1.Name = "treeView1";
                this.treeView1.Size = new System.Drawing.Size(240, 268);
                this.treeView1.TabIndex = 0;
                this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.AutoScroll = true;
                this.ClientSize = new System.Drawing.Size(240, 268);
                this.Controls.Add(this.treeView1);
                this.Menu = this.mainMenu1;
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
    
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                treeView1.Nodes.Add(new TreeViewNodeEx()
                {
                    Text = "Enabled"
                });
                treeView1.Nodes.Add(new TreeViewNodeEx()
                {
                    Text = "Disabled",
                    Enabled = false,
                });
            }
    
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
        }
    
        public class TreeViewEx 
            : TreeView
        {
            protected override void OnAfterSelect(TreeViewEventArgs e)
            {
                var node = e.Node as TreeViewNodeEx;
                if (node != null && !node.Enabled)
                {
                    return;
                }
                base.OnAfterSelect(e);
            }
        }
    
        public class TreeViewNodeEx 
            : TreeNode
        {
            private bool _enabled = true;
            public bool Enabled
            {
                get
                {
                    return _enabled;
                }
                set
                {
                    if (_enabled != value)
                    {
                        _enabled = value;
                        if (_enabled)
                        {
                            this.ForeColor = Color.Black;
                        }
                        else
                        {
                            this.ForeColor = Color.Gray;
                        }
                    }
                }
            }
    
        }
    }
