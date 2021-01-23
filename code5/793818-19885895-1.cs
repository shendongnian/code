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
                if (value.GetType() != typeof(RGBA))
                {
                    return value;
                }
                IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (svc != null)
                {
                    using (DialogColor form = new DialogColor((RGBA)value))
                    {
                        if (svc.ShowDialog(form) == DialogResult.OK)
                        {
                            return form.NewColor.RGBA;
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
                using (SolidBrush brush = new SolidBrush((RGBA)e.Value))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                e.Graphics.DrawRectangleProper(Pens.Black, e.Bounds);
            }
        }
    }
