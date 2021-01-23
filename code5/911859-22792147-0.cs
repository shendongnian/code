    namespace AndreasCoroiu.Controls
    {
        public partial class TaskbarThumbnail : UserControl
        {
            TaskbarForm taskbarForm;
            public TaskbarThumbnail()
            {
                InitializeComponent();
                if (!DesignMode)
                {
                    taskbarForm = new TaskbarForm();
                    TabbedThumbnail preview = new TabbedThumbnail(taskbarForm.Handle, taskbarForm.Handle);
                    TaskbarManager.Instance.TabbedThumbnail.AddThumbnailPreview(preview);
                    preview.TabbedThumbnailBitmapRequested += (o, e) =>
                    {
                        Bitmap bmp = new Bitmap(Width, Height);
                        DrawToBitmap(bmp, new Rectangle(new Point(0, 0), bmp.Size));
                        preview.SetImage(bmp);
                        e.Handled = true;
                    };
                }
            }
            public void Show()
            {
                taskbarForm.Show();
            }
            private class TaskbarForm : Form
            {
                public TaskbarForm()
                    : base()
                {
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
                protected override void OnLoad(EventArgs e)
                {
                    base.OnLoad(e);
                    Size = new System.Drawing.Size(0, 0);
                }
            }
        }
    }
