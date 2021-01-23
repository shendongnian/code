        class SavePrint : System.Windows.Forms.PrintPreviewDialog
        {
            readonly Form1 parent;
            public SavePrint(Form1 parent)
                : base()
            {
                this.parent = parent;
                // Remainder as before
            }
        }
