    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    class MyListView : ListView {
        public MyListView() {
            this.Columns.Add("Unnamed1");
            this.Columns.Add("Unnamed2");
            this.View = View.Details;
        }
        public string Column1Name {
            get { return this.Columns[0].Text; }
            set { this.Columns[0].Text = value; }
        }
        public string Column2Name {
            get { return this.Columns[1].Text; }
            set { this.Columns[1].Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ListView.ColumnHeaderCollection Columns {
            get { return base.Columns; }
        }
        protected override void OnClientSizeChanged(EventArgs e) {
            base.Columns[0].Width = this.ClientSize.Width / 2;
            base.Columns[1].Width = this.ClientSize.Width - base.Columns[0].Width;
            base.OnClientSizeChanged(e);
        }
    }
