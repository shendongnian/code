    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    namespace HelpersLib
    {
        public class MyColorEditor : UITypeEditor
        {
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.Modal;
            }
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                if (value.GetType() != typeof(Color))
                {
                    return value;
                }
                IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (svc != null)
                {
                    Color color = (Color)value;
                    using (DialogColor form = new DialogColor(color))
                    {
                        if (svc.ShowDialog(form) == DialogResult.OK)
                        {
                            return (Color)form.NewColor;
                        }
                    }
                }
                return value;
            }
            public override bool GetPaintValueSupported(ITypeDescriptorContext context)
            {
                return true;
            }
            public override void PaintValue(PaintValueEventArgs e)
            {
                Graphics g = e.Graphics;
                Color color = (Color)e.Value;
                if (color.A < 255)
                {
                    using (Image checker = ImageHelpers.CreateCheckers(e.Bounds.Width / 2, e.Bounds.Height / 2, Color.LightGray, Color.White))
                    {
                        g.DrawImage(checker, e.Bounds);
                    }
                }
                using (SolidBrush brush = new SolidBrush(color))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                e.Graphics.DrawRectangleProper(Pens.Black, e.Bounds);
            }
        }
    }
