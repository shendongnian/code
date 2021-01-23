    public class FormFontsResizeService
        {
            private const double EPSILON = 0.1;
            private readonly FontResizeFactorProvider _fontResizeFactorProvider;
    
            public FormFontsResizeService():this(new FontResizeFactorProvider())
            {
            }
    
            public FormFontsResizeService(FontResizeFactorProvider fontResizeFactorProvider)
            {
                _fontResizeFactorProvider = fontResizeFactorProvider;
            }
    
            public void ResizeControlFonts(Form form)
            {
                var resizeFactor = _fontResizeFactorProvider.GetFontResizeFactor();
    
                foreach (Control control in form.Controls)
                {
                    var baseFont = control.Font;
    
                    if (Math.Abs(baseFont.Size - SystemFonts.DefaultFont.Size) < EPSILON)
                    {
                        continue;
                    }
    
                    var scaledFont = new Font(baseFont.FontFamily, baseFont.Size*resizeFactor, baseFont.Style);
                    control.Font = scaledFont;
                }
            }
        }
